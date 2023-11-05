using UnityEngine;

/// <summary>
/// UIのマネージャークラス
/// </summary>
public class UIManager : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] ScoreController            scoreController;   // スコア管理クラス
    [SerializeField] ScoreUIController          scoreUIController; // スコアUI管理クラス
    [SerializeField] ItemUIController           itemUIController;  // アイテムUI管理クラス    
    [SerializeField] GoalBornus_Text_controller goalController;    // ゴール処理クラス

    void Update()
    {
        // スコアUIの更新命令
        scoreUIController.ScoreTextUpdate(scoreController.ScoreGetter());
        // アイテムUIの更新命令
        itemUIController.ItemTextUpdate(scoreController.ItemNumGetter());
    }

    /// <summary>
    /// ゴールした報告をうける
    /// </summary>
    public void GoalReport()
    {
        // ボーナスUI表示の命令
        goalController.GoalBornusUI_Active();
    }
}
