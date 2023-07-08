using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �v���C���[�̔�e���Ǘ�����X�N���v�g
////////////////////////////////////

public class CollisionCheck : MonoBehaviour
{
    //�U���̃^�O��
    string attackTag = "Attack";
    //�A�C�e���̃^�O��
    string ItemTag = "Item";

    //�_���[�W�^�C�}�[
    float damageDelta = 0;
    //�A�C�e���^�C�}�[
    float itemDelta = 0;
    //���̃_���[�W���󂯂�܂ł̃X�p��
    float damageSpan = 0.5f;
    //���̃A�C�e�����l������܂ł̃X�p��
    float itemGetSpan = 0.5f;

    //�C���X�y�N�^�[����ݒ�
    //�v���C���[�}�l�[�W���[�̃X�N���v�g
    public PlayerManager manager;

    private void Update()
    {
        //�^�C�}�[�̑���
        this.damageDelta += Time.deltaTime;
        this.itemDelta += Time.deltaTime;

        //�I�[�o�[�t���[�����Ȃ�����
        if(this.itemDelta > float.MaxValue)
        {
            this.itemDelta = 0;
        }
        if(this.damageDelta > float.MaxValue)
        {
            this.damageDelta = 0;
        }
    }

    /// <summary>
    /// �Փ˂����m���}�l�[�W���[�ɒm�点��
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //�Փ˂������̂��U���Ȃ̂��𒲂ׂ�
        //�A���ŏՓ˂��Ăяo���Ȃ��悤�X�p����݂���
        if (other.tag == this.attackTag && this.damageDelta > this.damageSpan)
        {
            //Debug.Log("�U���ƏՓ�");
            //�v���C���[�}�l�[�W���[�ɕ�
            manager.DamageReport();
            //�^�C�}�[������
            this.damageDelta = 0;
        }
        //�Փ˂������̂��U���Ȃ̂��𒲂ׂ�
        //�A���ŏՓ˂��Ăяo���Ȃ��悤�X�p����݂���
        if(other.tag == this.ItemTag && this.itemDelta > this.itemGetSpan)
        {
            Debug.Log("�A�C�e���ƏՓ�");
            //�v���C���[�}�l�[�W���[�ɕ�
            manager.ItemGetReport();
            //�^�C�}�[������
            this.itemDelta = 0;
        }
    }

}