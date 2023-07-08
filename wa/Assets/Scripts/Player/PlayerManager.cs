using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// プレイヤーのマネージャースクリプト
////////////////////////////////////
public class PlayerManager : MonoBehaviour
{
    //インスペクターから設定
    //接地判定のスクリプト
    public GroudCheck ground;
    //入力状態を返すスクリプト
    public ScreenInput screenInput;
    //現在のプレイヤー状態を返すスクリプト
    public Status status;
    //プレイヤーを動かすスクリプト
    public Move move;
    //アニメーションを管理するスクリプト
    public AnimationController anim;

    //接地フラグ入れる変数
    bool isGroudFlg = false;
    //プレイヤーの被弾フラグ
    bool playerDamageFlg = false;
    //プレイヤーのアイテム獲得フラグ
    bool playerItemGetFlg = false;

    //現在の入力状態を入れる変数
    ScreenInput.FlickDirection nowFlick;
    //現在のプレイヤー状態を入れる変数
    Status.situation nowSituation;

    void Start()
    {
        //コルーチン呼び出し
        StartCoroutine(status.ChangeSituation());
        StartCoroutine(anim.ChangeAnimaiton());
    }

    void Update()
    {
        //接地判定を受け取る
        this.isGroudFlg = this.ground.GetGroundStandFlg();
        //フリック方向を受け取る
        this.nowFlick = this.screenInput.GetNowFlick();
        //現在の状態を受け取る
        this.nowSituation = this.status.GetNowPlayerSituation();

        //ステータスの更新
        this.status.SituationUpdate(this.isGroudFlg, this.nowFlick);
        //移動の更新
        move.MovePlayerUpdate(this.nowFlick, this.nowSituation);
        //アニメーション更新
        anim.AnimationUpdate(this.nowFlick, this.nowSituation);

        //被弾フラグ立っている場合それぞれに被弾処理を命令する
        if(this.playerDamageFlg == true)
        {
            //Debug.Log("被弾処理開始");

            //フラグを下ろす
            this.playerDamageFlg = false;
        }

        //アイテム獲得フラグが立ってる場合それぞれに処理を命令
        if(this.playerItemGetFlg == true)
        {
            Debug.Log("アイテム獲得処理開始");

            //フラグを下ろす
            this.playerItemGetFlg = false;
        }
    }

    /// <summary>
    /// プレイヤーがダメージを受けた報告を受け取る
    /// </summary>
    public void DamageReport()
    {
        //プレイヤーの被弾フラグを立てる
        this.playerDamageFlg = true;
    }

    /// <summary>
    /// プレイヤーがアイテムをゲットした方向を受け取る
    /// </summary>
    public void ItemGetReport()
    {
        //アイテム獲得フラグを立てる
        this.playerItemGetFlg = true;
    }
}
