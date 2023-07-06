using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// プレイヤーのディレクタースクリプト
////////////////////////////////////
public class Manager : MonoBehaviour
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

    //接地判定を入れる変数
    bool isGroudFlg = false;
    //現在の入力状態を入れる変数
    ScreenInput.FlickDirection nowFlick;
    //現在のプレイヤー状態を入れる変数
    Status.situation nowSituation;


    void Start()
    {
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


    }
}
