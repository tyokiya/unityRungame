using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Status;
using static UnityEditor.PlayerSettings;

////////////////////////////////////
// �J�����̃R���g���[���[�X�N���v�g
////////////////////////////////////

public class CameraController : MonoBehaviour
{
    //�J�����̈ړ����x
    //float walkSpeed = 0.1f;
    //float runSpeed = 0.2f;
    //�e�X�g�p
    float walkSpeed = 0.001f;
    float runSpeed = 0.01f;

    //�ύX�O�̃v���C���[�̌���
    PlayerDirection beforeDirection = PlayerDirection.front;

    //�p�x�ɉ��Z�����񐔂��J�E���g����ϐ�
    int angleCnt = 0;

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
        this.angleCnt++;

        switch (direction)
        {
            case PlayerDirection.front:
                //�O����������@
                if (this.beforeDirection == PlayerDirection.left)
                {
                    transform.eulerAngles += new Vector3(0, 3.0f, 0);
                    transform.position += new Vector3(-0.1f, 0, -0.1f);
                }
                else if (this.beforeDirection == PlayerDirection.right)
                {
                    transform.eulerAngles -= new Vector3(0, 3.0f, 0);
                    transform.position += new Vector3(0.1f, 0, -0.1f);
                }
                //�J�E���g��30��ɂȂ������]��������
                //�v���C���[�̕ύX�O�̌������X�V
                if (this.angleCnt == 30)
                {
                    this.beforeDirection = PlayerDirection.front;
                    //�J�E���g������
                    this.angleCnt = 0;
                }
                break;
            case PlayerDirection.right:
                //�E����������@
                if(this.beforeDirection == PlayerDirection.front)
                {
                    transform.eulerAngles += new Vector3(0, 3.0f, 0);
                    transform.position += new Vector3(-0.1f, 0, 0.1f);
                }
                else if(this.beforeDirection == PlayerDirection.back)
                {
                    transform.eulerAngles -= new Vector3(0, 3.0f, 0);
                    transform.position += new Vector3(-0.1f, 0, -0.1f);
                }
                //�J�E���g��30��ɂȂ������]��������
                //�v���C���[�̕ύX�O�̌������X�V
                if (this.angleCnt == 30)
                {
                    this.beforeDirection = PlayerDirection.right;
                    //�J�E���g������
                    this.angleCnt = 0;
                }
                break;
            case PlayerDirection.back:
                //�����������@
                if (this.beforeDirection == PlayerDirection.right)
                {
                    transform.eulerAngles += new Vector3(0, 3.0f, 0);
                    transform.position += new Vector3(0.1f, 0, 0.1f);
                }
                else if (this.beforeDirection == PlayerDirection.left)
                {
                    transform.eulerAngles -= new Vector3(0, 3.0f, 0);
                    transform.position += new Vector3(-0.1f, 0, 0.1f);
                }
                //�J�E���g��30��ɂȂ������]��������
                //�v���C���[�̕ύX�O�̌������X�V
                if (this.angleCnt == 30)
                {
                    this.beforeDirection = PlayerDirection.back;
                    //�J�E���g������
                    this.angleCnt = 0;
                }
                break;
            case PlayerDirection.left:
                //������������@
                if (this.beforeDirection == PlayerDirection.back)
                {
                    transform.eulerAngles += new Vector3(0, 3.0f, 0);
                    transform.position += new Vector3(0.1f, 0, -0.1f);
                }
                else if (this.beforeDirection == PlayerDirection.front)
                {
                    transform.eulerAngles -= new Vector3(0, 3.0f, 0);
                    transform.position += new Vector3(0.1f, 0, 0.1f);
                }
                //�J�E���g��30��ɂȂ������]��������
                //�v���C���[�̕ύX�O�̌������X�V
                if (this.angleCnt == 30)
                {
                    this.beforeDirection = PlayerDirection.left;
                    //�J�E���g������
                    this.angleCnt = 0;
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
        //���݂̃v���C���[�̏�Ԃɉ����đ��x���w��
        if(situation == PlayerSituation.walk)
        {
            transform.position += new Vector3(0, 0, this.walkSpeed);
        }
        else if(situation == PlayerSituation.run)
        {
            switch (direction)
            {
                case PlayerDirection.front:
                    transform.position += new Vector3(0, 0, this.runSpeed);
                    break;
                case PlayerDirection.right:
                    transform.position += new Vector3(this.runSpeed, 0, 0);
                    break;
                case PlayerDirection.back:
                    transform.position += new Vector3(0, 0, this.runSpeed * -1);
                    break;
                case PlayerDirection.left:
                    transform.position += new Vector3(this.runSpeed * -1, 0, 0);
                    break;
            }
        }
    }
}
