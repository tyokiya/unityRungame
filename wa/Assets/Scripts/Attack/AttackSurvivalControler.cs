using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �U���̐�����Ԃ��Ǘ�����X�N���v�g
////////////////////////////////////

public class AttackSurvivalControler : MonoBehaviour
{
    
    //�U�����Ǘ�����}�l�[�W���[������
    GameObject attackManager;

    //�v���C���[�̍��W������ϐ�
    Vector3 plyPos;

    void Awake()
    {
        attackManager = GameObject.Find("AttackManager");
    }

    void Update()
    {
        //�}�l�[�W���[����v���C���[�̍��W���擾
        plyPos = attackManager.GetComponent<AttackManager>().GetPlayerPos();

        //�U���I�u�W�F�N�g���v�����[������ȏ㗣����
        //�I�u�W�F�N�g��j��
        if(plyPos.z - 2.0f > transform.position.z)
        {
            Destroy(gameObject);
            //Debug.Log("�U���I�u�W�F�N�g�j��");
        }
    }
}
