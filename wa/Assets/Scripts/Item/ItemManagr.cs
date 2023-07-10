using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagr : MonoBehaviour
{
    //�C���X�y�N�^�[����ݒ�
    //�U����������X�N���v�g
    public ItemGenerator generator;

    //�v���C���[�I�u�W�F�N�g������ϐ�
    GameObject player;

    //�U���̐����X�p���̊Ǘ��ϐ�
    [SerializeField] float itemSpan = 10.0f;

    //�^�C�}�[
    float itemDelta = 0;

    void Awake()
    {
        //�v���C���[�I�u�W�F�N�g���
        this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //�X�p���̊Ԋu�ɉ����ăA�C�e���̐����̎w��
        if(this.itemDelta > this.itemSpan)
        {
            this.generator.CreateItem(this.player.transform.position);
            //�f���^������
            this.itemDelta = 0;
        }

        //�f���^����
        this.itemDelta += Time.deltaTime;
    }
}
