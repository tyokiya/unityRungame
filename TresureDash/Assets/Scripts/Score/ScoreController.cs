using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

////////////////////////////////////
// 獲得スコアのコントローラースクリプト
////////////////////////////////////

public class ScoreController : MonoBehaviour
{
    //スコア
    int getItemCnt = 0;
    int getSucore  = 0;

    [Tooltip("ゴール時のボーナススコア定数")]
    const int bonusScore_const = 500;

    void Awake()
    {
        //リザルトシーンにスコアを残すためオブジェクトの破壊を行わない処理
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// スコア上昇処理
    /// </summary>
    public void ScoreUp()
    {
        this.getSucore++;
    }

    /// <summary>
    /// ゴール分アイテムスコア上昇
    /// </summary>
    public void GoalScoreUp()
    {
        this.getItemCnt += bonusScore_const;
    }

    /// <summary>
    /// 獲得アイテム数の上昇
    /// </summary>
    public void RiseItemSucore()
    {
        //Debug.Log("アイテム数上昇");
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
    public int ScoreGetter()
    {
        return this.getSucore;
    }

    /// <summary>
    /// スコアのリセット処理
    /// </summary>
    public void ScoreReset()
    {
        this.getItemCnt = 0;
        this.getSucore = 0;
    }
}
