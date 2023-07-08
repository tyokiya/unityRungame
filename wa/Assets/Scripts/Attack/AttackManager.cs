using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    //�C���X�y�N�^�[����ݒ�
    //�U����������X�N���v�g
    public AttackGenerator generator;

    //�v���C���[�I�u�W�F�N�g������ϐ�
    GameObject player;

    //�U���̐����X�p���̊Ǘ��ϐ�
    [SerializeField] float initialKnifeSpan = 3.0f;
    [SerializeField] float initialMakibishiSpan = 4.5f;

    //�^�C�}�[
    float knifeDelta = 0;
    float makibishiDelta = 0;
    
    void Awake()
    {
        //���
        this.player = GameObject.Find("Player");
    }


    void Update()
    {
        //�X�p���̊Ԋu�ɉ����čU���̐����̎w��
        if (this.knifeDelta > this.initialKnifeSpan)
        {
            //�i�C�t�U������
            generator.CreateKnife(this.player.transform.position);
            //�f���^������
            this.knifeDelta = 0;
        }
        if(this.makibishiDelta > this.initialMakibishiSpan)
        {
            //�܂��т�����
            generator.CreateMakibisi(this.player.transform.position);
            //�f���^������
            this.makibishiDelta = 0;
        }
        //�f���^����
        this.knifeDelta += Time.deltaTime;
        this.makibishiDelta += Time.deltaTime;
    }
}
