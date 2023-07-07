using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �v���C���[�̃}�l�[�W���[�X�N���v�g
////////////////////////////////////
public class PlayerManager : MonoBehaviour
{
    //�C���X�y�N�^�[����ݒ�
    //�ڒn����̃X�N���v�g
    public GroudCheck ground;
    //���͏�Ԃ�Ԃ��X�N���v�g
    public ScreenInput screenInput;
    //���݂̃v���C���[��Ԃ�Ԃ��X�N���v�g
    public Status status;
    //�v���C���[�𓮂����X�N���v�g
    public Move move;
    //�A�j���[�V�������Ǘ�����X�N���v�g
    public AnimationController anim;

    //�ڒn�t���O�����ϐ�
    bool isGroudFlg = false;
    //�v���C���[�̔�e�t���O
    bool PlayerDamageFlg = false;

    //���݂̓��͏�Ԃ�����ϐ�
    ScreenInput.FlickDirection nowFlick;
    //���݂̃v���C���[��Ԃ�����ϐ�
    Status.situation nowSituation;


    void Start()
    {
        StartCoroutine(status.ChangeSituation());
        StartCoroutine(anim.ChangeAnimaiton());
    }

    void Update()
    {
        //�ڒn������󂯎��
        this.isGroudFlg = this.ground.GetGroundStandFlg();
        //�t���b�N�������󂯎��
        this.nowFlick = this.screenInput.GetNowFlick();
        //���݂̏�Ԃ��󂯎��
        this.nowSituation = this.status.GetNowPlayerSituation();

        //�X�e�[�^�X�̍X�V
        this.status.SituationUpdate(this.isGroudFlg, this.nowFlick);
        //�ړ��̍X�V
        move.MovePlayerUpdate(this.nowFlick, this.nowSituation);
        //�A�j���[�V�����X�V
        anim.AnimationUpdate(this.nowFlick, this.nowSituation);

        //��e�t���O�����Ă���ꍇ���ꂼ��ɔ�e�����𖽗߂���
        if(this.PlayerDamageFlg == true)
        {
            Debug.Log("��e�����J�n");

            //�t���O�����낷
            this.PlayerDamageFlg = false;
        }
    }

    /// <summary>
    /// �v���C���[���_���[�W���󂯂��񍐂��󂯎��
    /// </summary>
    public void DamageReportAcceptance()
    {
        //�v���C���[�̔�e�t���O�𗧂Ă�
        this.PlayerDamageFlg = true;
    }
}
