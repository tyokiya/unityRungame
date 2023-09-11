using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
    
    [Tooltip("フェードイン処理のコントローラー")][SerializeField]
    FadeInScoreController fadeinScoreController_object;

    [Tooltip("ゴール処理のコントローラーオブジェクト")][SerializeField] 
    GoalBornus_Text_controller goalBornus_Text_Controller;

    [Tooltip("フェードイン処理した時の獲得アイテム数")]
    int fadeInItemNum = 0;

    [Tooltip("フェードイン処理を行うアイテムの個数定数")]
    const int fadeInNum_const = 50;

    void Update()
    {
        //スコアUIの更新命令
        this.scoreUIController_object.ScoreTextUpdate(this.scoreController_object.ScoreGetter());
        //アイテムUIの更新命令
        this.itemUIController_object.ItemTextUpdate(this.scoreController_object.ItemNumGetter());

        //獲得数50ごとにフェードイン処理命令
        //連続処理を防ぐため処理した時のアイテム数を保持し、比較し確認
        if (this.scoreController_object.ItemNumGetter() % fadeInNum_const == 0 && this.fadeInItemNum != this.scoreController_object.ItemNumGetter())
        {
            //フェードイン処理命令
            this.fadeinScoreController_object.fadeIn_itemScore(this.scoreController_object.ItemNumGetter());
            //処理時の獲得数保持
            this.fadeInItemNum = this.scoreController_object.ItemNumGetter();
        }
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
