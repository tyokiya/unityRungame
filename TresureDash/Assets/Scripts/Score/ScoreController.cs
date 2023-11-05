using UnityEngine;

/// <summary>
/// 獲得スコアのコントローラークラス
/// </summary>
public class ScoreController : MonoBehaviour
{
    // カウンター
    int getItemCnt = 0; // 獲得アイテム数
    int getSucore  = 0; // 獲得スコア

    // 定数
    const int BonusScore = 500; // ゴール時のボーナススコア定数

    void Awake()
    { 
        // リザルトシーンにスコアを残すためオブジェクトの破壊を行わない処理
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// スコア上昇処理
    /// </summary>
    public void ScoreUp()
    {
        getSucore++;
    }

    /// <summary>
    /// ゴール分アイテムスコア上昇
    /// </summary>
    public void GoalScoreUp()
    {
        getItemCnt += BonusScore;
    }

    /// <summary>
    /// 獲得アイテム数の上昇
    /// </summary>
    public void RiseItemSucore()
    {
        //Debug.Log("アイテム数上昇");
        getItemCnt++;
    }

    /// <summary>
    /// 獲得アイテム数のゲッター
    /// </summary>
    public int ItemNumGetter()
    {
        return getItemCnt;
    }

    /// <summary>
    /// 獲得スコアのゲッター
    /// </summary>
    public int ScoreGetter()
    {
        return getSucore;
    }

    /// <summary>
    /// スコアのリセット処理
    /// </summary>
    public void ScoreReset()
    {
        getItemCnt = 0;
        getSucore  = 0;
    }
}
