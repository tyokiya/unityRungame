using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �J�������Ǘ�����}�l�[�W���[�X�N���v�g
////////////////////////////////////

public class CameraManager : MonoBehaviour
{
    //�C���X�y�N�^�[����ݒ�
    //���͏�Ԃ�Ԃ��I�u�W�F�N�g
    public ScreenInput screenInput_object;
    //�J�����̓������Ǘ�����I�u�W�F�N�g
    public CameraController controller_object;
    //���݂̃v���C���[��Ԃ�Ԃ��I�u�W�F�N�g
    public Status playerStatus_object;

    //�v���C���[�I�u�W�F�N�g������ϐ�
    GameObject player;
    //���݂̓��͏�Ԃ�����ϐ�
    ScreenInput.FlickDirection nowFlick;
    //���݂̃v���C���[�̌����Ă����������ϐ�
    Status.PlayerDirection nowDirection;
    //���݂̃v���C���[�̏��
    Status.PlayerSituation nowSituation;

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
        this.nowDirection = this.playerStatus_object.GetNowPlayerDirection();
        //���݂̃v���C���[�̏�Ԃ��󂯎��
        this.nowSituation = this.playerStatus_object.GetNowPlayerSituation();
        //�t���b�N�������󂯎��
        this.nowFlick = this.screenInput_object.GetNowFlick();

        //�J�����̍X�V��������
        this.controller_object.UpdateCamera(playerPos, nowDirection, nowSituation);

    }

}
