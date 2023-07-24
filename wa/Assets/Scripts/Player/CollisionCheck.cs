using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �v���C���[�̔�e���Ǘ�����X�N���v�g
////////////////////////////////////

public class CollisionCheck : MonoBehaviour
{
    //�A�C�e���̃^�O��
    string ItemTag = "Item";

    //�A�C�e���^�C�}�[
    float itemDelta = 0;
    //���̃A�C�e�����l������܂ł̃X�p��
    float itemGetSpan = 0.05f;

    //�C���X�y�N�^�[����ݒ�
    //�v���C���[�}�l�[�W���[�̃X�N���v�g
    public PlayerManager manager;
    //�X�R�A�}�l�[�W���[
    public SucoreManager sucoreManager;


    private void Update()
    {
        //�^�C�}�[�̑���
        this.itemDelta += Time.deltaTime;

        //�I�[�o�[�t���[�����Ȃ�����
        if(this.itemDelta > float.MaxValue)
        {
            this.itemDelta = 0;
        }
    }

    /// <summary>
    /// �Փ˂����m���}�l�[�W���[�ɒm�点��
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //�Փ˂������̂��A�C�e���Ȃ̂��𒲂ׂ�
        //�A���ŏՓ˂��Ăяo���Ȃ��悤�X�p����݂���
        if(other.tag == this.ItemTag && this.itemDelta > this.itemGetSpan)
        {
            Debug.Log("�A�C�e���ƏՓ�");
            //�v���C���[�}�l�[�W���[�ɕ�
            sucoreManager.ItemGetReport();
            //�^�C�}�[������
            this.itemDelta = 0;
            //�l�������A�C�e���I�u�W�F�N�g��j��
            Destroy(other.gameObject);
        }
    }

}
