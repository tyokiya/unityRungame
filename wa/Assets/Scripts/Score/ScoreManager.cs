using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �l���X�R�A�̃}�l�[�W���[�X�N���v�g
////////////////////////////////////

public class ScoreManager : MonoBehaviour
{
    //�C���X�y�N�^�[����ݒ�
    //�X�R�A�Ǘ��̃I�u�W�F�N�g
    public ScoreController scoreController_object;
    

    //�v���C���[�̃A�C�e���l���t���O
    bool playerItemGetFlg = false;


    // Update is called once per frame
    void Update()
    {
        //�A�C�e���l���t���O�������Ă�ꍇ���ꂼ��ɏ����𖽗�
        if (this.playerItemGetFlg == true)
        {
            //Debug.Log("�A�C�e���l�������J�n");
            //�A�C�e���l�����㏸����
            this.scoreController_object.RiseItemSucore();

            //�t���O�����낷
            this.playerItemGetFlg = false;
        }

    }

    /// <summary>
    /// �v���C���[���A�C�e�����Q�b�g�����񍐂��󂯎��
    /// </summary>
    public void ItemGetReport()
    {
        //�A�C�e���l���t���O�𗧂Ă�
        this.playerItemGetFlg = true;
    }
}
