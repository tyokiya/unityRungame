using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �n�ʂ̃R���g���[���[�X�N���v�g
////////////////////////////////////

public class GroundController : MonoBehaviour
{
    //�v���C���[�̃^�O��
    string playerTag = "Player";
    //�e�I�u�W�F�N�g
    [SerializeField] GameObject ParentObject;

    /// <summary>
    /// �v���C���[�Ƃ̂��󂯎��I�u�W�F�N�g�j��̃R���[�`���Ăяo��
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        //�Փ˂������̂��v���C���[�Ȃ̂��𒲂ׂ�
        if (other.tag == this.playerTag)
        {
            StartCoroutine(GroundDestroyCoroutine());
        }
    }

    /// <summary>
    /// �v���C���[���G�ꂽ�n�ʂ����Ԍo�߂Ŕj�󂷂�
    /// </summary>

    public IEnumerator GroundDestroyCoroutine()
    {
        //4�b�ҋ@
        yield return new WaitForSeconds(4f);
        //Debug.Log("�O���E���h�R���[�`�����s");
        Destroy(ParentObject);
    }
}
