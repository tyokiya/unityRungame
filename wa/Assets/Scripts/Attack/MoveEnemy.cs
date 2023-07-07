using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    //�ړ����x
    //[SerializeField] float MoveSpeed = 0.3f;
    [SerializeField] Vector3 velocity = new Vector3(0f, 0f, -5f);

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
