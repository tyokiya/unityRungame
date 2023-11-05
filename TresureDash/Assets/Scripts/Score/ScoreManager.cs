using UnityEngine;

/// <summary>
/// スコアのマネージャークラス
/// </summary>
public class ScoreManager : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] ScoreController scoreController; // スコア管理クラス
    [SerializeField] Status          playerState;     // プレイヤーの状態管理クラス

    Status.PlayerAlive currentAlive; // プレイヤーの生死状態管理

    bool playerItemGetFlg = false; // アイテム獲得フラグ

    void Awake()
    {
        // オブジェクト生成時スコアのリセット処理を呼ぶ
        scoreController.ScoreReset();
    }

    void Update()
    {
        // 現在の生死状態を受け取る
        currentAlive = playerState.GetNowPlayerSurvival();

        // アイテム獲得フラグが立ってる場合それぞれに処理を命令
        if (playerItemGetFlg)
        {
            //Debug.Log("アイテム獲得処理開始");
            // アイテム獲得数上昇処理
            scoreController.RiseItemSucore();

            // フラグを下ろす
            playerItemGetFlg = false;
        }

        // プレイヤーが生存状態ならスコア上昇命令
        if(currentAlive == Status.PlayerAlive.Life)
        {
            scoreController.ScoreUp();
        }
    }

    /// <summary>
    /// プレイヤーがアイテムをゲットした報告を受け取る
    /// </summary>
    public void ItemGetReport()
    {
        // アイテム獲得フラグを立てる
        playerItemGetFlg = true;
    }

    /// <summary>
    /// プレイヤーがゴールアイテムをゲットした報告を受ける
    /// </summary>
    public void GoalItemGetReport()
    {
        // コントローラーにゴールスコア上昇処理
        scoreController.GoalScoreUp();
    }
}
