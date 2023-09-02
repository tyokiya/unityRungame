﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// 獲得スコアのマネージャースクリプト
////////////////////////////////////

public class ScoreManager : MonoBehaviour
{
    //インスペクターから設定
    [Tooltip("スコア管理オブジェクト")][SerializeField] 
    ScoreController scoreController_object;
    
    [Tooltip("現在のプレイヤー状態を管理するオブジェクト")][SerializeField] 
    Status playerStatus_object;

    bool playerItemGetFlg = false;

    [Tooltip("プレイヤーの生死状態")]
    Status.PlayerSurvival nowSurvival;

    //オブジェクト生成時スコアのリセット処理を呼ぶ
    void Awake()
    {
        this.scoreController_object.ScoreReset();
    }

    void Update()
    {
        //現在の生死状態を受け取る
        this.nowSurvival = this.playerStatus_object.GetNowPlayerSurvival();

        //アイテム獲得フラグが立ってる場合それぞれに処理を命令
        if (this.playerItemGetFlg == true)
        {
            //Debug.Log("アイテム獲得処理開始");
            //アイテム獲得数上昇処理
            this.scoreController_object.RiseItemSucore();

            //フラグを下ろす
            this.playerItemGetFlg = false;
        }

        //プレイヤーが生存状態ならスコア上昇命令
        if(this.nowSurvival == Status.PlayerSurvival.life)
        {
            this.scoreController_object.ScoreUp();
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

    /// <summary>
    /// プレイヤーがゴールアイテムをゲットした報告を受ける
    /// </summary>
    public void GoalItemGetReport()
    {
        //コントローラーにゴールスコア上昇処理
        this.scoreController_object.GoalScoreUp();
    }
}