using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

////////////////////////////////////
// アイテムスコア50ごとにフェードインするスコアコントローラー
////////////////////////////////////
public class FadeInScoreController : MonoBehaviour
{
    //インスペクターから設定
    [Tooltip("子オブジェクト")][SerializeField]
    Text child_score_object;

    [Tooltip("フェードインフラグ")]
    bool fadeInFlg = false;

    [Tooltip("フェードインのカウンタ")]
    int fadeIn_counter = 0;

    const float fadeIn_speed_const  = -3.0f;
    const int counsterMax_num_const = 70;

    [Tooltip("初期位置")]
    Vector3 initPos = new Vector3 (0, 230f, 0);

    void Update()
    {
        //フラグに応じてフェードイン処理
        if (this.fadeInFlg)
        {
            //y軸移動
            transform.Translate(0, fadeIn_speed_const, 0);
            //カウンター増加
            this.fadeIn_counter++;
        }
        //カウンター数がマックスまで達したらフラグを下ろし初期値へ移動
        if (this.fadeIn_counter == counsterMax_num_const)
        {
            //初期値へ移動
            transform.Translate(this.initPos);
            //フラグを下ろす
            this.fadeInFlg = false;
            //カウンター初期化
            this.fadeIn_counter = 0;
        }
    }

    /// <summary>
    /// スコアのフェードイン処理
    /// </summary>
    /// <param name="displayScore">表示するスコア</param>
    public void fadeIn_itemScore(int displayScore)
    {
        //フェードインフラグを立てる
        this.fadeInFlg = true;
        //表示するスコアを更新
        this.child_score_object.text = displayScore.ToString();
    }
}
