using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �v���C���[���Ǘ�����}�l�[�W���[�X�N���v�g
////////////////////////////////////
public class PlayerManager : MonoBehaviour
{
    //�C���X�y�N�^�[����ݒ�
    //�ڒn����̃X�N���v�g
    public GroudCheck ground;
    //���͏�Ԃ�Ԃ��X�N���v�g
    public ScreenInput screenInput;
    //���݂̃v���C���[��Ԃ��Ǘ��X�N���v�g
    public Status status;
    //�v���C���[�𓮂����X�N���v�g
    public Move move;
    //�A�j���[�V�������Ǘ�����X�N���v�g
    public AnimationController anim;
   

    //�ڒn�t���O�����ϐ�
    bool isGroudFlg = false;
    //�^�[���\�Ȓn�ʂƂ̐ݒu�t���O������
    bool isTurnGroundFlg = false;

    //�v���C���[�̗��������y���W�{�[�_�[
    float playerFallBorder_y = -2.0f;

    //���݂̓��͏�Ԃ�����ϐ�
    ScreenInput.FlickDirection nowFlick;
    //���݂̃v���C���[��Ԃ�����ϐ�
    Status.PlayerSituation nowSituation;
    //���݂̃v���C���[�̐�����Ԃ�����ϐ�
    Status.PlayerSurvival nowSurvival;
    //���݂̃v���C���[�̌����Ă����������ϐ�
    Status.PlayerDirection nowDirection;
    //���݂̃v���C���[�̍��W������ϐ�
    Vector3 nowPosition;

    void Start()
    {
        //�R���[�`���Ăяo��
        StartCoroutine(status.ChangeSituation());
        StartCoroutine(anim.ChangeAnimaiton());
    }

    void Update()
    {
        //�ڒn������󂯎��
        this.isGroudFlg = this.ground.GetGroundStandFlg();
        this.isTurnGroundFlg = this.ground.GetTurnGroundStandFlg();


        //�t���b�N�������󂯎��
        this.nowFlick = this.screenInput.GetNowFlick();
        //���݂̏�Ԃ��󂯎��
        this.nowSituation = this.status.GetNowPlayerSituation();
        //���݂̐�����Ԃ��󂯎��
        this.nowSurvival = this.status.GetNowPlayerSurvival();
        //���݂̃v���C���[�̌����Ă�������󂯎��
        this.nowDirection = this.status.GetNowPlayerDirection();

        //�X�e�[�^�X�̍X�V
        this.status.SituationUpdate(this.isGroudFlg, this.nowFlick, this.isTurnGroundFlg);
        //�ړ��̍X�V
        this.move.MovePlayerUpdate(this.nowFlick, this.nowSituation, this.nowDirection , this.isGroudFlg);
        //�A�j���[�V�����X�V
        this.anim.AnimationUpdate(this.nowFlick, this.nowSituation);

        
    }

    
}
