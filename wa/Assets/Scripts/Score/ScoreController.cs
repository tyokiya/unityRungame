using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    //獲得アイテム数
    int getItemCnt = 0;
    //獲得スコア
    int getSucore = 0;

    void Update()
    {
        //1フレームごとにスコアを1づつ増加
        this.getSucore++;
    }

    /// <summary>
    /// 獲得アイテム数の上昇
    /// </summary>
    public void RiseItemSucore()
    {
        Debug.Log("アイテム数上昇");
        this.getItemCnt++;
    }

    /// <summary>
    /// 獲得アイテム数のゲッター
    /// </summary>
    public int ItemNumGetter()
    {
        return this.getItemCnt;
    }

    /// <summary>
    /// 獲得スコアのゲッター
    /// </summary>
    public int SucoreGetter()
    {
        return this.getSucore;
    }
}
