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
    bool playerDamageFlg = false;
    //�v���C���[�̃A�C�e���l���t���O
    bool playerItemGetFlg = false;

    //���݂̓��͏�Ԃ�����ϐ�
    ScreenInput.FlickDirection nowFlick;
    //���݂̃v���C���[��Ԃ�����ϐ�
    Status.situation nowSituation;

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
        if(this.playerDamageFlg == true)
        {
            //Debug.Log("��e�����J�n");

            //�t���O�����낷
            this.playerDamageFlg = false;
        }

        //�A�C�e���l���t���O�������Ă�ꍇ���ꂼ��ɏ����𖽗�
        if(this.playerItemGetFlg == true)
        {
            Debug.Log("�A�C�e���l�������J�n");

            //�t���O�����낷
            this.playerItemGetFlg = false;
        }
    }

    /// <summary>
    /// �v���C���[���_���[�W���󂯂��񍐂��󂯎��
    /// </summary>
    public void DamageReport()
    {
        //�v���C���[�̔�e�t���O�𗧂Ă�
        this.playerDamageFlg = true;
    }

    /// <summary>
    /// �v���C���[���A�C�e�����Q�b�g�����������󂯎��
    /// </summary>
    public void ItemGetReport()
    {
        //�A�C�e���l���t���O�𗧂Ă�
        this.playerItemGetFlg = true;
    }
}
