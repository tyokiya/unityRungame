using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �v���C���[�̃R���g���[���[�X�N���v�g
////////////////////////////////////

public class PlayerController : MonoBehaviour
{
    //�A�j���[�^�[������ϐ�
    Animator animator;
    //���W�b�h�{�f�B������ϐ�
    Rigidbody rd;

    //�W�����v��
    float jumpForce = 500.0f;
    //�ړ��X�s�[�h
    float walkSpeed = 0.1f;
    float runSpeed = 0.2f;

    //�^�C�}�[
    float delta = 0;
    float startTime = 3.0f;

    //�����Ă��邩�̃t���O
    bool runFlg = false;
    //�X���C�v���W
    Vector3 swipStartPos;
    //�X���C�v�̋���������ϐ�
    float swipLengthX, swipLengthY;

    void Start()
    {
        //�t���[�����[�g�Œ�
        Application.targetFrameRate = 30;
        //�R���|�[�l���g�擾
        this.animator = GetComponent<Animator>();
        this.rd = GetComponent<Rigidbody>();
    }

  
    void Update()
    {
        //�J�n����3�b��v���C���[������n�߂�
        if(this.delta > this.startTime && runFlg == false)
        {
            //run�t���O�����Ă�
            this.runFlg = true;
            //run�A�j���[�V�����̃g���K�[�ɐ؂�ւ���
            this.animator.SetTrigger("RunTrigger");
        }
        else
        {
            //�J�E���g�̑���
            this.delta += Time.deltaTime;
        }

        //�X���C�v�̒��������߂�
        if(Input.GetMouseButtonDown(0))
        {
            //�N���b�N���W�擾
            this.swipStartPos = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            //�N���b�N�𗣂������W
            Vector3 endPos = Input.mousePosition;
            //�X���C�v�������v�Z
            this.swipLengthX = endPos.x - this.swipStartPos.x;
            this.swipLengthY = endPos.y - this.swipStartPos.y;
        }

        //�W�����v����
        if(this.swipLengthY > 100 && this.rd.velocity.y == 0 && this.runFlg == true)
        {
            //�W�����v�A�j���[�V�����̃g���K�[�ɐ؂�ւ���
            this.animator.SetTrigger("JumpTrigger");
            //y���ɗ͂�������
            this.rd.AddForce(transform.up * this.jumpForce);
            //�����O�X������
            this.swipLengthY = 0;
        }

        //���E�ړ�����
        

        //�t���O�ňړ����x��ς���
        if(this.runFlg == false)
        {
            //�������x
            transform.Translate(0,0,this.walkSpeed);
        }
        else
        {
            //���葬�x
            transform.Translate(0,0,this.runSpeed);
        }
    }
}
