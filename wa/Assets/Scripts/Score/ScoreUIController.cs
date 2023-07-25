using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIController : MonoBehaviour
{
    //�X�R�A�I�u�W�F�N�g������ϐ�
    public GameObject score_object;

    //�X�R�A�e�L�X�g������ϐ�
    Text score_text;

    void Awake()
    {
        //�e�L�X�g�R���|�[�l���g���擾
        score_text = score_object.GetComponent<Text>();
    }

    /// <summary>
    /// �`�悷��X�R�A���X�V����
    /// </summary>
    /// <param name="score">���݂̃v���C���[�̃X�R�A</param>
    public void ScoreTextUpdate(int score)
    {
        //int�^��string�^�ɕϊ�
        string s = score.ToString();
        //�X�R�A�X�V
        this.score_text.text = s;
    }
}
