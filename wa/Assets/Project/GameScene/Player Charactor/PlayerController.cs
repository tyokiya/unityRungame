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
    //���͏�Ԃ�����ϐ�
    GameObject inputDetector;

    //�W�����v��
    [SerializeField]
    private float jumpForce = 500.0f;
    //�ړ��X�s�[�h
    [SerializeField] 
    private float walkSpeed = 0.1f;
    private float runSpeed = 0.2f;
    //���ړ�����
    private float lateralDistance = 0.8f;

    //�^�C�}�[
    float delta = 0;
    float startTime = 3.0f;
    //�ړ��\�^�C�~���O�̃X�p��
    float lateralMoveSpan = 0.1f;

    //�����Ă��邩�̃t���O
    bool runFlg = false;
   

    void Start()
    {
        //�t���[�����[�g�Œ�
        Application.targetFrameRate = 30;
        //�R���|�[�l���g�擾
        this.animator = GetComponent<Animator>();
        this.rd = GetComponent<Rigidbody>();
        //�I�u�W�F�N�g������

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

        //InputDetector������͏�Ԃ��󂯎��
        GameObject inputDetector = GameObject.Find("InputDetector");
        //���͏�Ԃɉ����Ĉړ�
        switch (inputDetector.GetComponent<ScreenInput>().GetNowFlick())
        {
            case ScreenInput.FlickDirection.UP:         //�W�����v����
                PlayerJump();
                break;
            case ScreenInput.FlickDirection.RIGHT:      //�E�ړ�����
                //�A���ŏ������Ȃ��悤�X�p����݂���
                if(this.delta > this.lateralMoveSpan && this.runFlg == true)
                {
                    PlayerLateralMoveMent(true);
                }
                else //���E�ړ����ł��Ȃ��ꍇ�͑O�֐i��
                {
                    PlayerMove(this.runFlg);
                }
                
                break;
            case ScreenInput.FlickDirection.LEFT:       //���ړ�����
                //�A���ŏ������Ȃ��悤�X�p����݂���
                if (this.delta > this.lateralMoveSpan && this.runFlg == true)
                {
                    PlayerLateralMoveMent(false);
                }
                else //���E�ړ����ł��Ȃ��ꍇ�͑O�֐i��
                {
                    PlayerMove(this.runFlg);
                }
                break;
                default:
                PlayerMove(this.runFlg);                //�v���C���[�̑O�ړ�(�t���O�̏�Ԃő��x��ς���)
                break;
        }

        //�J�E���g�̑���
        this.delta += Time.deltaTime;
    }

    /// <summary>
    /// �v���C���[�̃W�����v����
    /// </summary>
    void PlayerJump()
    {
        if (this.rd.velocity.y == 0 && this.runFlg == true)
        {
            //�W�����v�A�j���[�V�����̃g���K�[�ɐ؂�ւ���
            this.animator.SetTrigger("JumpTrigger");
            //y���ɗ͂�������
            this.rd.AddForce(transform.up * this.jumpForce);
        }
    }
    
    /// <summary>
    /// �v���C���[�̈ړ�
    /// </summary>
    /// <param name="flg">�v���C���[���������邩�̃t���O</param>
    void PlayerMove(bool flg)
    {
        if (flg == false)
        {
            //�������x
            transform.Translate(0, 0, this.walkSpeed);
        }
        else
        {
            //���葬�x
            transform.Translate(0, 0, this.runSpeed);
        }
    }

    /// <summary>
    /// �v���C���[�̉��ړ�
    /// </summary>
    /// <param name="rightFlg">�E�ړ��̃t���O(false�̂Ƃ��͍��ɓ���)</param>
    void PlayerLateralMoveMent(bool rightFlg)
    {
        if (rightFlg == true && transform.position.x < 0.8)    //�E�ړ�
        {
            transform.Translate(this.lateralDistance, 0, this.runSpeed);
        }
        else if (rightFlg == false && transform.position.x > -0.8)//���ړ� 
        {
            transform.Translate(this.lateralDistance * -1, 0, this.runSpeed);
        }

        //delta������
        this.delta = 0;
    }
}
