using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �A�C�e���̓����𐧌䂷��X�N���v�g
////////////////////////////////////
public class ItemController : MonoBehaviour
{
    //�A�C�e���̉�]�X�s�[�h
    float rotateSpeed = 10.0f;

    void Update()
    {
        //���̑��x�ŉ�]
        transform.eulerAngles += new Vector3(0, this.rotateSpeed, 0);
    }
}
