using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�A�j���[�^�[������ϐ�
    Animator animator;
    //���W�b�h�{�f�B������ϐ�
    Rigidbody rd;
    //�W�����v��
    float jumpForce = 500.0f;

    void Start()
    {
        //�R���|�[�l���g�擾
        this.animator = GetComponent<Animator>();
        this.rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //�W�����v����
        if(Input.GetKeyDown(KeyCode.Space) && this.rd.velocity.y == 0)
        {
            //�W�����v�A�j���[�V�����̃g���K�[�ɐ؂�ւ���
            this.animator.SetTrigger("JumpTrigger");
            //y���ɗ͂�������
            this.rd.AddForce(transform.up * this.jumpForce);
        }
    }
}
