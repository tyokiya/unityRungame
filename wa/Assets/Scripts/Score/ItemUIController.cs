using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIController : MonoBehaviour
{
    //�X�R�A�I�u�W�F�N�g������ϐ�
    [SerializeField] GameObject item_object;

    //�X�R�A�e�L�X�g������ϐ�
    Text item_text;

    void Awake()
    {
        //�e�L�X�g�R���|�[�l���g���擾
        item_text = item_object.GetComponent<Text>();
    }

    /// <summary>
    /// �`�悷��X�R�A���X�V����
    /// </summary>
    /// <param name="score">���݂̃v���C���[�̃X�R�A</param>
    public void ItemTextUpdate(int score)
    {
        //int�^��string�^�ɕϊ�
        string s = score.ToString();
        //�X�R�A�X�V
        this.item_text.text = s;
    }
}
