using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    //�l���A�C�e����
    int getItemCnt = 0;
    //�l���X�R�A
    int getSucore = 0;

    void Update()
    {
        //1�t���[�����ƂɃX�R�A��1�Â���
        this.getSucore++;
    }

    /// <summary>
    /// �l���A�C�e�����̏㏸
    /// </summary>
    public void RiseItemSucore()
    {
        Debug.Log("�A�C�e�����㏸");
        this.getItemCnt++;
    }

    /// <summary>
    /// �l���A�C�e�����̃Q�b�^�[
    /// </summary>
    public int ItemNumGetter()
    {
        return this.getItemCnt;
    }

    /// <summary>
    /// �l���X�R�A�̃Q�b�^�[
    /// </summary>
    public int SucoreGetter()
    {
        return this.getSucore;
    }
}
