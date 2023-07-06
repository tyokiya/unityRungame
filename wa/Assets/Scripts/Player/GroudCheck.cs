using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroudCheck : MonoBehaviour
{
    //�n�ʂ̃^�O��
    string groundTag = "Ground";
    //�n�ʂɗ����Ă��邩
    bool StandGroundFlg = true;

    /// <summary>
    /// �Փ˂��󂯎��t���O�𗧂Ă�
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == groundTag)
        {
            this.StandGroundFlg = true;
        }
    }

    /// <summary>
    /// ���肪�Ȃ��Ȃ�����t���O�����낷
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        this.StandGroundFlg = false;
    }
    /// <summary>
    /// �v���C���[���n�ʂɗ����Ă��邩�̃t���O��Ԃ�
    /// </summary>
    /// <returns></returns>
    public bool GetGroundStandFlg()
    {
        return StandGroundFlg;
    }

}
