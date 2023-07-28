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
    //�C���X�y�N�^�[����ݒ�
    //�v���C���[�}�l�[�W���[�̃I�u�W�F�N�g
    public PlayerManager playerManager_object;
    //�e�I�u�W�F�N�g
    GameObject ParentObject;

    //���W�b�h�{�f�B������ϐ�
    Rigidbody rb;
    Transform pos;

    [SerializeField]
    //�W�����v��
    private float jumpForce = 500.0f;

    //�d�͂̍ő�l
    float maxGrabity = -3.0f;

    //�����X�s�[�h
    [SerializeField] float walkSpeed = 1f;
    //����X�s�[�h
    [SerializeField] float runSpeed = 5f;
    //�����Ă鎞�̃x���V�e�B
    Vector3 moveVelocity = new Vector3(0f, 0f, 0f);

    

    void Awake()
    {
        //�e�I�u�W�F�N�g���擾
        ParentObject = GameObject.Find("Player");
        //�R���|�[�l���g�擾
        this.rb = ParentObject.GetComponent<Rigidbody>();
        this.pos = ParentObject.GetComponent<Transform>();
    }



    /// <summary>
    /// �v���C���[����͏�Ԃɉ����ē�����
    /// </summary>
    /// <param name="flick">���݂̓��͏��</param>
    /// <param name="situation">���݂̃v���C���[�̏��</param>
    /// <param name="direction">���݂̃v���C���[�̌����Ă����</param>
    /// <param name="groudFlg">�ڒn�t���O</param>
    public void MovePlayerUpdate(ScreenInput.FlickDirection flick, Status.PlayerSituation situation, Status.PlayerDirection direction ,bool groudFlg)
    {

        //velosity�̍X�V
        VelocityUpdate(situation, direction);

        //�W�����v����
        if (flick == ScreenInput.FlickDirection.UP && situation == Status.PlayerSituation.run && groudFlg == true)
        {
            Debug.Log("�W�����v����");
            //�W�����v
            PlayerJump();
        }

        //�ړ�����
        if (situation == Status.PlayerSituation.run || situation == Status.PlayerSituation.walk)
        {
            rb.velocity = this.moveVelocity;
        }

        //���݂̌����ɍ��킹�ăv���C���[����]
        RotationPlayer(direction);
    }

    /// <summary>
    /// �v���C���[�̌����Ă�����Ə�Ԃɍ��킹��velosity�̍X�V
    /// </summary>
    /// <param name="situation">���݂̃v���C���[�̏��</param>
    /// <param name="direction">���݂̃v���C���[�̌����Ă����</param>
    void VelocityUpdate(Status.PlayerSituation situation, Status.PlayerDirection direction)
    {

        if (situation == PlayerSituation.walk)
        {
            this.moveVelocity = new Vector3(0f, 0f, this.walkSpeed);
        }
        else
        {
            switch (direction)
            {
                case PlayerDirection.front:
                    this.moveVelocity = new Vector3(0f, 0, this.runSpeed);
                    break;
                case PlayerDirection.right:
                    this.moveVelocity = new Vector3(this.runSpeed, 0, 0f);
                    break;
                case PlayerDirection.back:
                    this.moveVelocity = new Vector3(0f, 0, this.runSpeed * -1);
                    break;
                case PlayerDirection.left:
                    this.moveVelocity = new Vector3(this.runSpeed * -1, 0, 0f);
                    break;
            }
        }
    }

    /// <summary>
    /// �v���C���[�̃W�����v����
    /// </summary>
    void PlayerJump()
    {
        //y���ɗ͂�������
        this.rb.AddForce(transform.up * this.jumpForce, ForceMode.Impulse);
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

    /// <summary>
    /// �v���C���[�̈ړ��x���V�e�B�̃Q�b�^�[
    /// </summary>
    public Vector3 PlayerVelocityGetter()
    {
        return this.moveVelocity;
    }
}
