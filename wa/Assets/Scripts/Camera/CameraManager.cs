using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �J�������Ǘ�����}�l�[�W���[�X�N���v�g
////////////////////////////////////

public class CameraManager : MonoBehaviour
{
    //�C���X�y�N�^�[����ݒ�
    //���͏�Ԃ�Ԃ��X�N���v�g
    public ScreenInput screenInput;
    //�J�����̓������Ǘ�����X�N���v�g
    public CameraController controller;
    //���݂̃v���C���[��Ԃ�Ԃ��X�N���v�g
    public Status status;

    //�v���C���[�I�u�W�F�N�g������ϐ�
    GameObject player;
    //���݂̓��͏�Ԃ�����ϐ�
    ScreenInput.FlickDirection nowFlick;
    //���݂̃v���C���[�̌����Ă����������ϐ�
    Status.PlayerDirection nowDirection;

    void Awake()
    {
        //���
        this.player = GameObject.Find("Player");
    }

    void Update()
    {
        //�v���C���[�̍��W���擾
        Vector3 playerPos = this.player.transform.position;
        //���݂̃v���C���[�̌����Ă�������󂯎��
        this.nowDirection = this.status.GetNowPlayerDirection();
        //�t���b�N�������󂯎��
        this.nowFlick = this.screenInput.GetNowFlick();

        //�J�����̍X�V��������
        this.controller.UpdateCamera(playerPos, nowDirection);

    }

}
