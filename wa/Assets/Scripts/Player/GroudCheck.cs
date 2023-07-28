using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �n�ʂ̏Փ˂��Ǘ�����X�N���v�g
////////////////////////////////////

public class GroudCheck : MonoBehaviour
{
    //�n�ʂ̃^�O��
    string groundTag = "Ground";
    string turnGroundTag = "TurnGround";
    //�n�ʂɗ����Ă��邩
    bool standGroundFlg = true;
    bool standTurnGroundFlg = false;

    /// <summary>
    /// �Փ˂��󂯎��t���O�𗧂Ă�
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        //�Փ˂������̂��n�ʂȂ̂��𒲂ׂ�
        if (other.tag == this.groundTag)
        {
            this.standGroundFlg = true;
            //Debug.Log("1");

        }
        else if(other.tag == this.turnGroundTag)
        {
            this.standGroundFlg = true;
            this.standTurnGroundFlg = true;
        }
    }

    /// <summary>
    /// ���肪�Ȃ��Ȃ�����t���O�����낷
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        //�Փ˂������̂��n�ʂȂ̂��𒲂ׂ�
        if (other.tag == this.groundTag)
        {
            this.standGroundFlg = false;
            //Debug.Log("2");
        }
        else if (other.tag == this.turnGroundTag)
        {
            this.standGroundFlg = false;
            this.standTurnGroundFlg = false;
        }
    }
    /// <summary>
    /// �v���C���[���n�ʂɗ����Ă��邩�̃t���O��Ԃ�
    /// </summary>
    /// <returns></returns>
    public bool GetGroundStandFlg()
    {
        return standGroundFlg;
    }

    public bool GetTurnGroundStandFlg()
    {
        return standTurnGroundFlg;
    }

}
