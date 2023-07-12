using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �U���𐶐�����X�N���v�g
////////////////////////////////////

public class AttackGenerator : MonoBehaviour
{
    //�U���̃v���t�@�u������ϐ�
    public GameObject KnifePrefab;
    public GameObject makibishiPrefab;

    //��x�ɐ�������U���̌�
    [SerializeField] int knifeNum = 1;

    //�i�C�t�������̃v���C���[�Ƃ̋���
    [SerializeField] float knifeDistance = 30.0f;
    //�܂��т��������̃v���C���[�Ƃ̋���
    [SerializeField] float makibishiDistance = 20.0f;

    /// <summary>
    /// �i�C�t�U���𐶐�
    /// </summary>
    /// <param name="plyPos">�v���C���[�̍��W</param>
    public void CreateKnife(Vector3 plyPos)
    {
        //���݂̐����������ɍU���𐶐�
        if (this.knifeNum == 1)
        {
            GameObject knife = Instantiate(this.KnifePrefab);
            //���W�ݒ�
            int dice = Random.Range(-1, 2);
            knife.transform.position = new Vector3(0.8f * dice, 0, plyPos.z + this.knifeDistance);
        }
        else if (this.knifeNum == 2)
        {
            GameObject knife = Instantiate(this.KnifePrefab);
            GameObject knife2 = Instantiate(this.KnifePrefab);
            //���W�ݒ�
            int dice = Random.Range(-1, 2);
            int dice2 = dice;
            //�ʂ̒l���ł���܂Ń��[�v
            while(dice2 == dice)
            {
                dice2 = Random.Range(-1, 2);
            }
            knife2.transform.position = new Vector3(0.8f * dice, 0, plyPos.z + this.knifeDistance);

        }
    }

    /// <summary>
    /// �܂��т��𐶐�
    /// </summary>
    /// <param name="plyPos">�v���C���[�̍��W</param>
    public void CreateMakibisi(Vector3 plyPos)
    {
        //�U���̐���
        GameObject makibishi = Instantiate(this.makibishiPrefab);
        //���W�ݒ�
        makibishi.transform.position = new Vector3(plyPos.x, 0, plyPos.z + this.makibishiDistance);
    }

    /// <summary>
    /// �i�C�t�̐���������
    /// </summary>
    /// <param name="changeNum">�ς��鐶����</param>
    public void SetKnifeNum(int changeNum)
    {
        this.knifeNum = changeNum;
    }
}
