using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Status;

////////////////////////////////////
// �J�����̃R���g���[���[�X�N���v�g
////////////////////////////////////

public class CameraController : MonoBehaviour
{
    //�J�����ƃv���C���[�̈�苗��
    float playerDistance = 3.5f;

    //�^�C�}�[
    float delta = 0;
    //��]�\�^�C�~���O�̃X�p��
    float rotationSpan = 0.1f;

    void Update()
    {
        //delta����
        this.delta += Time.deltaTime;

    }

    /// <summary>
    /// �J�����̏��X�V
    /// </summary>
    /// <param name="playerPos">���݂̃v���C���[�̍��W</param>
    /// <param name="flick">���݂̓��͏��</param>
    public void UpdateCamera(Vector3 playerPos, ScreenInput.FlickDirection flick)
    {
        //�t���b�N�ɉ����ď���
        switch (flick)
        {
            case ScreenInput.FlickDirection.RIGHT:          //�E�Ɍ�������
                RotationCamera(true);
                break;
            case ScreenInput.FlickDirection.LEFT:           //���Ɍ�������
                RotationCamera(false);
                break;
        }

        //��Ɉ��̋�����ۂ��Ȃ���v���C���[��Ǐ]
        transform.position = new Vector3(transform.position.x, transform.position.y, playerPos.z - playerDistance);

    }

    /// <summary>
    /// �J�����̌�����]����
    /// </summary>
    /// <param name="rightFlg">�E�ɉ�]����ꍇ�̃t���O</param>
    void RotationCamera(bool rightFlg)
    {
        //�t���O�ŉ�]�̌����w��
        //�A���ŏ�������Ȃ��悤�ɃX�p����݂���
        if(rightFlg == true && this.delta > this.rotationSpan )
        {
            //�E����������@
            transform.eulerAngles = new Vector3(0, 90.0f, 0);
            //delta������
            this.delta = 0;
        }
        else if(rightFlg == false && this.delta > this.rotationSpan)
        {
            //������������@
            transform.eulerAngles = new Vector3(0, -90.0f, 0);
            //delta������
            this.delta = 0;
        }
    }
}
