using UnityEngine;

////////////////////////////////////
// UIマネージャースクリプト
////////////////////////////////////
public class UIManager : MonoBehaviour
{
    //インスペクターから設定
    [Tooltip("スコア管理オブジェクト")][SerializeField] 
    ScoreController scoreController_object;

    [Tooltip("スコアUI管理オブジェクト")][SerializeField] 
    ScoreUIController scoreUIController_object;
    
    [Tooltip("アイテムUI管理オブジェクト")][SerializeField]
    ItemUIController itemUIController_object;
    
    [Tooltip("ゴール処理のコントローラーオブジェクト")][SerializeField] 
    GoalBornus_Text_controller goalBornus_Text_Controller;

    void Update()
    {
        //スコアUIの更新命令
        this.scoreUIController_object.ScoreTextUpdate(this.scoreController_object.ScoreGetter());
        //アイテムUIの更新命令
        this.itemUIController_object.ItemTextUpdate(this.scoreController_object.ItemNumGetter());
    }

    /// <summary>
    /// ゴールした報告をうける
    /// </summary>
    public void GoalReport()
    {
        //ボーナスUI表示の命令
        this.goalBornus_Text_Controller.GoalBornusUI_Active();
    }
}
