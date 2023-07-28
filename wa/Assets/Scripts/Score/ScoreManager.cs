using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// 獲得スコアのマネージャースクリプト
////////////////////////////////////

public class ScoreManager : MonoBehaviour
{
    //インスペクターから設定
    //スコア管理のオブジェクト
    public ScoreController scoreController_object;
    

    //プレイヤーのアイテム獲得フラグ
    bool playerItemGetFlg = false;


    // Update is called once per frame
    void Update()
    {
        //アイテム獲得フラグが立ってる場合それぞれに処理を命令
        if (this.playerItemGetFlg == true)
        {
            //Debug.Log("アイテム獲得処理開始");
            //アイテム獲得数上昇処理
            this.scoreController_object.RiseItemSucore();

            //フラグを下ろす
            this.playerItemGetFlg = false;
        }

    }

    /// <summary>
    /// プレイヤーがアイテムをゲットした報告を受け取る
    /// </summary>
    public void ItemGetReport()
    {
        //アイテム獲得フラグを立てる
        this.playerItemGetFlg = true;
    }
}
