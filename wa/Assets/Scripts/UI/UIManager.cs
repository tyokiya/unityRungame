using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //�C���X�y�N�^�[����ݒ�
    //�X�R�A�Ǘ��̃I�u�W�F�N�g
    [SerializeField] ScoreController scoreController_object;
    //�X�R�AUI�Ǘ��I�u�W�F�N�g
    [SerializeField] ScoreUIController scoreUIController_object;
    //�A�C�e��UI�Ǘ��I�u�W�F�N�g
    [SerializeField] ItemUIController itemUIController_object;

    void Update()
    {
        //�X�R�AUI�̍X�V����
        this.scoreUIController_object.ScoreTextUpdate(this.scoreController_object.SucoreGetter());
        //�A�C�e��UI�̍X�V����
        this.itemUIController_object.ItemTextUpdate(this.scoreController_object.ItemNumGetter());
    }
}
