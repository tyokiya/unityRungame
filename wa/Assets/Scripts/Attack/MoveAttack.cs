using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �N�i�C�̓������Ǘ�����X�N���v�g
////////////////////////////////////

public class MoveAttack : MonoBehaviour
{
    //�ړ����x
  
    Vector3 velocity = new Vector3(0f, 0f, -80f);

    //�R���|�[�l���g������ϐ�
    Rigidbody rd;

    void Awake()
    {
        //�R���|�[�l���g�擾
        rd = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //�v���C���[�Ɍ������Ĉړ�
        rd.velocity = this.velocity;
    }
}
