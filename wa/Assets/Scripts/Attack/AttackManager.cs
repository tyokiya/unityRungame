using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �U�����Ǘ�����}�l�[�W���[�X�N���v�g
////////////////////////////////////

public class AttackManager : MonoBehaviour
{
    //�C���X�y�N�^�[����ݒ�
    //�U����������X�N���v�g
    public AttackGenerator generator;

    //�v���C���[�I�u�W�F�N�g������ϐ�
    GameObject player;

    //�U���̐����X�p���̊Ǘ��ϐ�
    [SerializeField] float knifeSpan = 3.0f;
    [SerializeField] float makibishiSpan = 4.5f;

    //��Փx�A�b�v�̃X�p��
    [SerializeField] float levelUpSpan = 15.0f;
    //���݂̃Q�[����Փx
    int nowGameLevel = 1;

    //�^�C�}�[
    float knifeDelta = 0;
    float makibishiDelta = 0;
    float gameDelta = 0;
    
    void Awake()
    {
        //�v���C���[�I�u�W�F�N�g���
        this.player = GameObject.Find("Player");
    }


    void Update()
    {
        //�X�p���̊Ԋu�ɉ����čU���̐����̎w��
        if (this.knifeDelta > this.knifeSpan)
        {
            //�i�C�t�U������
            generator.CreateKnife(this.player.transform.position);
            //�f���^������
            this.knifeDelta = 0;
        }
        if(this.makibishiDelta > this.makibishiSpan)
        {
            //�܂��т�����
            generator.CreateMakibisi(this.player.transform.position);
            //�f���^������
            this.makibishiDelta = 0;
        }

        //levelUpSpan�������琶���X�p���Ɛ��������グ��
        if(this.gameDelta > this.levelUpSpan && this.nowGameLevel == 1)
        {
            //���x���A�b�v
            this.nowGameLevel = 2;
            //�i�C�t�̐������A�b�v�̎w��
            generator.SetKnifeNum(2);
            //�U���̐����X�p�����k�߂�
            ChangeSpan(2.0f, 3.0f);
            
        }


        //�f���^����
        this.knifeDelta += Time.deltaTime;
        this.makibishiDelta += Time.deltaTime;
        if(this.nowGameLevel == 1)
        {
            this.gameDelta += Time.deltaTime;
        }
    }

    /// <summary>
    /// �v���C���[�̍��W���U���ɕԂ�
    /// </summary>
    /// <returns>�v���C���[���W</returns>
    public Vector3 GetPlayerPos()
    {
        return player.transform.position;
    }

    /// <summary>
    /// �U���̐����X�p���ύX
    /// </summary>
    /// <param name="changeKnifeSpan">�ύX����i�C�t�̃X�p��</param>
    /// <param name="changeMakibishiSpan">�ύX����܂��т��̃X�p��</param>
    void ChangeSpan(float changeKnifeSpan, float changeMakibishiSpan)
    {
        this.knifeSpan = changeKnifeSpan;
        this.makibishiSpan = changeMakibishiSpan;
    }
}
