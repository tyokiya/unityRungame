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
    //�J�����ƃv���C���[�̈�苗��
    float playerDistance = 3.5f;

    /// <summary>
    /// �J�����̏��X�V
    /// </summary>
    /// <param name="playerPos">���݂̃v���C���[�̍��W</param>
    /// <param name="direction">���݂̃v���C���[�̌����Ă����</param>
    public void UpdateCamera(Vector3 playerPos, Status.PlayerDirection direction)
    {
        //�v���C���[�̌����Ă���������Ƃ�
        //�J�����̌�����ς���
        RotationCamera(direction);

        //�v���C���[�̌����Ă���������Ƃ�
        //��Ɉ��̋�����ۂ��Ȃ���v���C���[��Ǐ]
        MoveCamera(playerPos,direction);

    }

    /// <summary>
    /// �J�����̌�����]����
    /// </summary>
    /// <param name="direction">���݂̃v���C���[�̌����Ă����</param>
    void RotationCamera(Status.PlayerDirection direction)
    {
        switch (direction)
        {
            case PlayerDirection.front:
                //�O����������@
                transform.eulerAngles = new Vector3(20.0f,0, 0);
                break;
            case PlayerDirection.right:
                //�E����������@
                transform.eulerAngles = new Vector3(20.0f, 90.0f, 0);
                break;
            case PlayerDirection.back:
                //�����������@
                transform.eulerAngles = new Vector3(20.0f, 180.0f, 0);
                break;
            case PlayerDirection.left:
                //������������@
                transform.eulerAngles = new Vector3(20.0f, 270.0f, 0);
                break;
        }
    }

    /// <summary>
    /// �J�����̒Ǐ]����
    /// </summary>
    /// <param name="playerPos">���݂̃v���C���[�̍��W</param>
    /// <param name="direction">���݂̃v���C���[�̌����Ă����</param>
    void MoveCamera(Vector3 playerPos, Status.PlayerDirection direction)
    {
        switch (direction)
        {
            case PlayerDirection.front:
                transform.position = new Vector3(playerPos.x, transform.position.y, playerPos.z - playerDistance);
                break;
            case PlayerDirection.right:
                transform.position = new Vector3(playerPos.x - playerDistance, transform.position.y, playerPos.z);
                break;
            case PlayerDirection.back:
                transform.position = new Vector3(playerPos.x, transform.position.y, playerPos.z + playerDistance);
                break;
            case PlayerDirection.left:
                transform.position = new Vector3(playerPos.x + playerDistance, transform.position.y, playerPos.z);
                break;
        }
    }
}
