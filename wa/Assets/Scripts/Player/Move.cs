using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using static Status;

////////////////////////////////////
// �v���C���[�̓������Ǘ�����X�N���v�g
////////////////////////////////////

public class Move : MonoBehaviour
{
    //�e�I�u�W�F�N�g
    GameObject ParentObject;

    //���W�b�h�{�f�B������ϐ�
    Rigidbody rd;
    Transform pos;

    [SerializeField]
    //�W�����v��
    private float jumpForce = 500.0f;

    //�����X�s�[�h
    [SerializeField] float walkSpeed = 1f;
    //����X�s�[�h
    [SerializeField] float runSpeed = 5f;
    //�����Ă鎞�̃x���V�e�B
    Vector3 Velocity = new Vector3(0f, 0f, 0f);

    //�e�X�g�p�X�s�[�h
    //float walkSpeed = 0.001f;
    //float runSpeed = 0.01f;


    //�C���X�y�N�^�[����ݒ�
    //�v���C���[�}�l�[�W���[�̃X�N���v�g
    public PlayerManager manager;

    void Awake()
    {
        //�e�I�u�W�F�N�g���擾
        ParentObject = GameObject.Find("Player");
        //�R���|�[�l���g�擾
        this.rd = ParentObject.GetComponent<Rigidbody>();
        this.pos = ParentObject.GetComponent<Transform>();
    }

    /// <summary>
    /// �v���C���[����͏�Ԃɉ����ē�����
    /// </summary>
    /// <param name="flick">���݂̓��͏��</param>
    /// <param name="situation">���݂̃v���C���[�̏��</param>
    /// <param name="direction">���݂̃v���C���[�̌����Ă����</param>
    public void MovePlayerUpdate(ScreenInput.FlickDirection flick, Status.PlayerSituation situation, Status.PlayerDirection direction)
    {

        //�����Ă�����Ə�Ԃɍ��킹��velosity�̍X�V
        if (situation == PlayerSituation.walk)
        {
            this.Velocity = new Vector3(0f, 0f, this.walkSpeed);
        }
        else
        {
            switch (direction)
            {
                case PlayerDirection.front:
                    this.Velocity = new Vector3(0f, 0f, this.runSpeed);
                    break;
                case PlayerDirection.right:
                    this.Velocity = new Vector3(this.runSpeed, 0f, 0f);
                    break;
                case PlayerDirection.back:
                    this.Velocity = new Vector3(0f, 0f, this.runSpeed * -1);
                    break;
                case PlayerDirection.left:
                    this.Velocity = new Vector3(this.runSpeed * -1, 0f, 0f);
                    break;
            }
        }

        //�ړ�����
        if(situation == Status.PlayerSituation.run || situation == Status.PlayerSituation.walk)
        {
            rd.velocity = this.Velocity;
        }

        //�W�����v����
        if (flick == ScreenInput.FlickDirection.UP && situation == Status.PlayerSituation.run)
        {
            //�W�����v
            PlayerJump();
        }

        //���݂̌����ɍ��킹�ăv���C���[����]
        RotationPlayer(direction);

  
    }

    /// <summary>
    /// �v���C���[�̃W�����v����
    /// </summary>
    void PlayerJump()
    {
        //y���ɗ͂�������
        this.rd.AddForce(transform.up * this.jumpForce);
    }


    /// <summary>
    /// �v���C���[�̌�������]
    /// </summary>
    /// <param name="direction">�v���C���[�̌����Ă����</param>
    void RotationPlayer(Status.PlayerDirection direction)
    {
        //�X�e�[�^�X�̌����Ă�����ɉ����ĉ�]
        switch(direction)
        {
            case PlayerDirection.front:
                //�O����������@
                this.pos.eulerAngles = new Vector3(0, 0, 0);
                break;
            case PlayerDirection.right:
                //�E����������@
                this.pos.eulerAngles = new Vector3(0, 90.0f, 0);
                break;
            case PlayerDirection.back:
                //�����������@
                this.pos.eulerAngles = new Vector3(0, 180.0f, 0);
                break;
            case PlayerDirection.left:
                //������������@
                this.pos.eulerAngles = new Vector3(0, 270.0f, 0);
                break;
        }
    }
}
