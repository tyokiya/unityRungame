using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �n�ʂ̃R���g���[���[�X�N���v�g
////////////////////////////////////

public class GroundController : MonoBehaviour
{
    void Update()
    {
        GameObject camera;
        //�J�����I�u�W�F�N�g�ێ�
        camera = GameObject.Find("Main Camera");

        //�n�ʂ��v���C���[�����ɏo�����_�Ŕj��
        if(camera.transform.position.z > transform.position.z + 5.0f)
        {
            //�I�u�W�F�N�g�j��
            Destroy(gameObject);
        }
    }
}
