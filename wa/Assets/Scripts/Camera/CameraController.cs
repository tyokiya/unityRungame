using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Status;

////////////////////////////////////
// �J�����̃R���g���[���[�X�N���v�g
////////////////////////////////////

public class CameraController : MonoBehaviour
{
    //�J�����̐U��������x
    float turnAngleSpeed = 6.0f;
    float turnMoveSpeed = 0.2f;

    //�v���C���[�ƃJ�����̋���
    float playerDirection = 5.0f;

    //�ύX�O�̃v���C���[�̌���
    PlayerDirection beforeDirection = PlayerDirection.front;

    //�p�x�ɉ��Z�����񐔂��J�E���g����ϐ�
    int turnCnt = 0;
    //�U������̃}�b�N�X��
    int maxTurnCnt = 15;

    /// <summary>
    /// �J�����̏��X�V
    /// </summary>
    /// <param name="playerPos">���݂̃v���C���[�̍��W</param>
    /// <param name="direction">���݂̃v���C���[�̌����Ă����</param>
    /// <param name="situation">���݂̃v���C���[�̏��</param>
    public void UpdateCamera(Vector3 playerPos, PlayerDirection nowDirection, PlayerSituation situation)
    {
        //�v���C���[�̌����Ă�����ɕύX����������
        //�J�����̌�����ς���(����o���Ĉȍ~)
        if(situation == PlayerSituation.run && nowDirection != this.beforeDirection)
        {
            RotationCamera(nowDirection);
        }
        //�v���C���[�̌����Ă���������Ƃ�
        //��Ɉ��̋�����ۂ��Ȃ���v���C���[��Ǐ]
        MoveCamera(playerPos, nowDirection, situation);
    }

    /// <summary>
    /// �J�����̌�����]����
    /// </summary>
    /// <param name="direction">���݂̃v���C���[�̌����Ă����</param>
    void RotationCamera(PlayerDirection direction)
    {
        //�J�E���g����
        this.turnCnt++;

        switch (direction)
        {
            case PlayerDirection.front:
                //�O����������@
                if (this.beforeDirection == PlayerDirection.left)
                {
                    transform.eulerAngles += new Vector3(0, this.turnAngleSpeed, 0);
                    transform.position += new Vector3(-turnMoveSpeed, 0, -turnMoveSpeed);
                }
                else if (this.beforeDirection == PlayerDirection.right)
                {
                    transform.eulerAngles -= new Vector3(0, this.turnAngleSpeed, 0);
                    transform.position += new Vector3(turnMoveSpeed, 0, -turnMoveSpeed);
                }
                //�J�E���g��30��ɂȂ������]��������
                //�v���C���[�̕ύX�O�̌������X�V
                if (this.turnCnt == this.maxTurnCnt)
                {
                    this.beforeDirection = PlayerDirection.front;
                    //�J�E���g������
                    this.turnCnt = 0;
                }
                break;
            case PlayerDirection.right:
                //�E����������@
                if(this.beforeDirection == PlayerDirection.front)
                {
                    transform.eulerAngles += new Vector3(0, this.turnAngleSpeed, 0);
                    transform.position += new Vector3(-turnMoveSpeed, 0, turnMoveSpeed);
                }
                else if(this.beforeDirection == PlayerDirection.back)
                {
                    transform.eulerAngles -= new Vector3(0, this.turnAngleSpeed, 0);
                    transform.position += new Vector3(-turnMoveSpeed, 0, -turnMoveSpeed);
                }
                //�J�E���g��30��ɂȂ������]��������
                //�v���C���[�̕ύX�O�̌������X�V
                if (this.turnCnt == this.maxTurnCnt)
                {
                    this.beforeDirection = PlayerDirection.right;
                    //�J�E���g������
                    this.turnCnt = 0;
                }
                break;
            case PlayerDirection.back:
                //�����������@
                if (this.beforeDirection == PlayerDirection.right)
                {
                    transform.eulerAngles += new Vector3(0, this.turnAngleSpeed, 0);
                    transform.position += new Vector3(turnMoveSpeed, 0, turnMoveSpeed);
                }
                else if (this.beforeDirection == PlayerDirection.left)
                {
                    transform.eulerAngles -= new Vector3(0, this.turnAngleSpeed, 0);
                    transform.position += new Vector3(-turnMoveSpeed, 0, turnMoveSpeed);
                }
                //�J�E���g��30��ɂȂ������]��������
                //�v���C���[�̕ύX�O�̌������X�V
                if (this.turnCnt == this.maxTurnCnt)
                {
                    this.beforeDirection = PlayerDirection.back;
                    //�J�E���g������
                    this.turnCnt = 0;
                }
                break;
            case PlayerDirection.left:
                //������������@
                if (this.beforeDirection == PlayerDirection.back)
                {
                    transform.eulerAngles += new Vector3(0, this.turnAngleSpeed, 0);
                    transform.position += new Vector3(turnMoveSpeed, 0, -turnMoveSpeed);
                }
                else if (this.beforeDirection == PlayerDirection.front)
                {
                    transform.eulerAngles -= new Vector3(0, this.turnAngleSpeed, 0);
                    transform.position += new Vector3(turnMoveSpeed, 0, turnMoveSpeed);
                }
                //�J�E���g��30��ɂȂ������]��������
                //�v���C���[�̕ύX�O�̌������X�V
                if (this.turnCnt == this.maxTurnCnt)
                {
                    this.beforeDirection = PlayerDirection.left;
                    //�J�E���g������
                    this.turnCnt = 0;
                }
                break;
        }
    }

    /// <summary>
    /// �J�����̒Ǐ]����
    /// </summary>
    /// <param name="playerPos">���݂̃v���C���[�̍��W</param>
    /// <param name="direction">���݂̃v���C���[�̌����Ă����</param>
    void MoveCamera(Vector3 playerPos, PlayerDirection direction, PlayerSituation situation)
    {
        if(situation == PlayerSituation.walk)
        {
            transform.position = new Vector3(playerPos.x, transform.position.y, playerPos.z - this.playerDirection);
        }
        else
        {
            switch (direction)
            {
                case PlayerDirection.front:
                    transform.position = new Vector3(playerPos.x, transform.position.y, playerPos.z - this.playerDirection);

                    break;
                case PlayerDirection.right:
                    transform.position = new Vector3(playerPos.x - this.playerDirection, transform.position.y, playerPos.z);
                    break;
                case PlayerDirection.back:
                    transform.position = new Vector3(playerPos.x, transform.position.y, playerPos.z + this.playerDirection);
                    break;
                case PlayerDirection.left:
                    transform.position = new Vector3(playerPos.x + this.playerDirection, transform.position.y, playerPos.z);
                    break;
            }
        }
    }
}
