using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //インスペクターから設定
    //スコア管理のオブジェクト
    [SerializeField] ScoreController scoreController_object;
    //スコアUI管理オブジェクト
    [SerializeField] ScoreUIController scoreUIController_object;
    //アイテムUI管理オブジェクト
    [SerializeField] ItemUIController itemUIController_object;

    void Update()
    {
        //スコアUIの更新命令
        this.scoreUIController_object.ScoreTextUpdate(this.scoreController_object.SucoreGetter());
        //アイテムUIの更新命令
        this.itemUIController_object.ItemTextUpdate(this.scoreController_object.ItemNumGetter());
    }
}
