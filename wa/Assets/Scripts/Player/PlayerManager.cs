using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �v���C���[���Ǘ�����}�l�[�W���[�X�N���v�g
////////////////////////////////////
public class PlayerManager : MonoBehaviour
{
    //�C���X�y�N�^�[����ݒ�
    //�ڒn����̃I�u�W�F�N�g
    public GroudCheck groundCheck_object;
    //���͏�Ԃ�Ԃ��I�u�W�F�N�g
    public ScreenInput screenInput_object;
    //���݂̃v���C���[��Ԃ��Ǘ��I�u�W�F�N�g
    public Status playerStatus_object;
    //�v���C���[�𓮂����I�u�W�F�N�g
    public Move playerMove_object;
    //�A�j���[�V�������Ǘ�����I�u�W�F�N�g
    public AnimationController playerAnimation_object;
   

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
        StartCoroutine(playerStatus_object.ChangeSituation());
        StartCoroutine(playerAnimation_object.ChangeAnimaiton());
    }

    void Update()
    {
        //�ڒn������󂯎��
        this.isGroudFlg = this.groundCheck_object.GetGroundStandFlg();
        this.isTurnGroundFlg = this.groundCheck_object.GetTurnGroundStandFlg();

        //�t���b�N�������󂯎��
        this.nowFlick = this.screenInput_object.GetNowFlick();
        //���݂̏�Ԃ��󂯎��
        this.nowSituation = this.playerStatus_object.GetNowPlayerSituation();
        //���݂̐�����Ԃ��󂯎��
        this.nowSurvival = this.playerStatus_object.GetNowPlayerSurvival();
        //���݂̃v���C���[�̌����Ă�������󂯎��
        this.nowDirection = this.playerStatus_object.GetNowPlayerDirection();

        //�X�e�[�^�X�̍X�V
        this.playerStatus_object.SituationUpdate(this.isGroudFlg, this.nowFlick, this.isTurnGroundFlg);
        //�ړ��̍X�V
        this.playerMove_object.MovePlayerUpdate(this.nowFlick, this.nowSituation, this.nowDirection , this.isGroudFlg);
        //�A�j���[�V�����X�V
        this.playerAnimation_object.AnimationUpdate(this.nowFlick, this.nowSituation);
    }
}
