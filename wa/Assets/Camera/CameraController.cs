using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //�v���C���[�I�u�W�F�N�g������ϐ�
    GameObject player;
    void Start()
    {
        //���
        this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�̍��W���擾
        Vector3 playerPos = this.player.transform.position;

        //��Ɉ��̋�����ۂ��Ȃ���v���C���[��Ǐ]
        transform.position = new Vector3(transform.position.x, transform.position.y, playerPos.z - 3.5f);
    }
}
