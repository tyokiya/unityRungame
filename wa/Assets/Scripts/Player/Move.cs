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
    
    //���W�b�h�{�f�B������ϐ�
    [SerializeField] Rigidbody rd;
    //�e�I�u�W�F�N�g�̃g�����X�t�H�[��������ϐ�
    [SerializeField] Transform parent_transform;

    //�W�����v��
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] float down_jumpForce = 0.08f;
    float now_jumpForce = 0;

    //�����X�s�[�h
    [SerializeField] float walkSpeed = 1f;
    //����X�s�[�h
    [SerializeField] float runSpeed = 5f;
    //�����Ă鎞�̃x���V�e�B
    Vector3 moveVelocity = new Vector3(0f, 0f, 0f);

    private void Update()
    {
        //���t���[���W�����v�͂̌���(0�ȉ��ɂȂ邱�Ƃ͂Ȃ�)
        if(now_jumpForce > 0)
        {
            this.now_jumpForce -= this.down_jumpForce;
            if(this.now_jumpForce < 0)
            {
                this.now_jumpForce = 0;
            }
        }
    }

    /// <summary>
    /// �v���C���[����͏�Ԃɉ����ē�����
    /// </summary>
    /// <param name="flick">���݂̓��͏��</param>
    /// <param name="situation">���݂̃v���C���[�̏��</param>
    /// <param name="direction">���݂̃v���C���[�̌����Ă����</param>
    public void MovePlayerUpdate(ScreenInput.FlickDirection flick, Status.PlayerSituation situation, Status.PlayerDirection direction)
    {
        //�W�����v�̓��͂ŃW�����v�͂�����
        if (flick == ScreenInput.FlickDirection.UP && situation == Status.PlayerSituation.run)
        {
            //���݂̃W�����v�͂ɗ͂���
            this.now_jumpForce = this.jumpForce;
        }

        //�ړ�����
        MovePlayer(situation, direction);

        //���݂̌����ɍ��킹�ăv���C���[����]
        RotationPlayer(direction);
    }

    /// <summary>
    /// �v���C���[�̈ړ�����
    /// </summary>
    /// <param name="situation">���݂̃v���C���[�̏��</param>
    /// <param name="direction">���݂̃v���C���[�̌����Ă����</param>
    void MovePlayer(Status.PlayerSituation situation, Status.PlayerDirection direction)
    {
        if (situation == PlayerSituation.walk)
        {
            this.rd.MovePosition(new Vector3(parent_transform.position.x, parent_transform.position.y, parent_transform.position.z + walkSpeed));
        }
        else
        {
            switch (direction)
            {
                case PlayerDirection.front:
                    this.rd.MovePosition(new Vector3(parent_transform.position.x, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z + runSpeed));
                    break;
                case PlayerDirection.right:
                    this.rd.MovePosition(new Vector3(parent_transform.position.x + runSpeed, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z));
                    break;
                case PlayerDirection.back:
                    this.rd.MovePosition(new Vector3(parent_transform.position.x, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z - runSpeed));
                    break;
                case PlayerDirection.left:
                    this.rd.MovePosition(new Vector3(parent_transform.position.x - runSpeed, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z));
                    break;
            }
        }
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
                this.parent_transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case PlayerDirection.right:
                //�E����������@
                this.parent_transform.eulerAngles = new Vector3(0, 90.0f, 0);
                break;
            case PlayerDirection.back:
                //�����������@
                this.parent_transform.eulerAngles = new Vector3(0, 180.0f, 0);
                break;
            case PlayerDirection.left:
                //������������@
                this.parent_transform.eulerAngles = new Vector3(0, 270.0f, 0);
                break;
        }
    }

}
