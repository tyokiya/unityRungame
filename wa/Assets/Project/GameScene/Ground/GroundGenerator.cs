using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �n�ʂ𐶐�����X�N���v�g
////////////////////////////////////

public class GroundGenerator : MonoBehaviour
{
    //�n�ʂ�prefab������ϐ�
    public GameObject groundPrefab;
    //�����Ԋu�𑪂�^�C�}�[
    [SerializeField] private float span = 1.5f;
    float delta = 0;
    //���������n�ʂ̖����J�E���^�[
    int GroundCnt = 0;

    void Start()
    {
        //�n��10��������
        for(int i = 0; i < 10; i++)
        {
            //�J�E���g����
            this.GroundCnt++;

            //�������\�b�h�Ăяo��
            CreateGround(GroundCnt);
        }
    }

    void Update()
    {
        //delta�J�E���g����
        this.delta += Time.deltaTime;
        //3�b���Ƃɒn�ʐ���
        if(this.delta > this.span)
        {
            //delta������
            this.delta = 0;

            //�J�E���g����
            this.GroundCnt++;

            //�������\�b�h�Ăяo��
            CreateGround(GroundCnt);
        }
    }

    /// <summary>
    /// �n�ʂ𐶐����郁�\�b�h
    /// </summary>
    /// <param name="groundCnt">���������n�ʂ̖����J�E���^�[</param>
    void CreateGround(int groundCnt)
    {
        //�C���X�^���X����
        GameObject ground = Instantiate(groundPrefab);
        ground.transform.position = new Vector3(0, 0, groundCnt * 10);
    }
}
