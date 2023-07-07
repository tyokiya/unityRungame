using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �v���C���[�̔�e���Ǘ�����X�N���v�g
////////////////////////////////////

public class DamageCheck : MonoBehaviour
{
    //�U���̃^�O��
    string attackTag = "Attack";

    //�^�C�}�[
    float delta = 0;
    //�ړ��\�^�C�~���O�̃X�p��
    float damageSpan = 0.5f;

    //�C���X�y�N�^�[����ݒ�
    //�v���C���[�}�l�[�W���[�̃X�N���v�g
    public PlayerManager manager;

    private void Update()
    {
        //�f���^�^�C���̑���
        this.delta += Time.deltaTime;
    }

    /// <summary>
    /// �Փ˂����m���}�l�[�W���[�ɒm�点��
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //�Փ˂������̂��n�ʂȂ̂��𒲂ׂ�
        //�A���ŏՓ˂��Ăяo���Ȃ��悤�X�p����݂���
        if (other.tag == attackTag && this.delta > this.damageSpan)
        {
            //Debug.Log("�U���ƏՓ�");
            manager.DamageReportAcceptance();
            //�^�C�}�[������
            this.delta = 0;
        }
    }

}
