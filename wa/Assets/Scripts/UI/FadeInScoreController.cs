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
    //子オブジェクトのスコアオブジェクトを入れる
    [SerializeField] Text child_score_object;

    //フェードインスピード
    float fadeIn_speed = -3.0f;
    //フェードインフラグ
    bool fadeInFlg = false;
    //フェードインの回数カウンター
    int fadeIn_counter = 0;
    //カウンターのマックス数
    int counsterMax_num = 70;

    void Update()
    {
        //フラグに応じてフェードイン処理
        if (this.fadeInFlg == true)
        {
            //y軸移動
            transform.Translate(0, this.fadeIn_speed, 0);
            //カウンター増加
            this.fadeIn_counter++;
        }
        //カウンター数がマックスまで達したらフラグを下ろし初期値へ移動
        if (this.fadeIn_counter == this.counsterMax_num)
        {
            //初期値へ移動
            transform.Translate(0, 230, 0);
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
