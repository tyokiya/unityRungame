using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// プレイヤーを管理するマネージャースクリプト
////////////////////////////////////
public class PlayerManager : MonoBehaviour
{
    //インスペクターから設定
    //接地判定のスクリプト
    public GroudCheck ground;
    //入力状態を返すスクリプト
    public ScreenInput screenInput;
    //現在のプレイヤー状態を管理スクリプト
    public Status status;
    //プレイヤーを動かすスクリプト
    public Move move;
    //アニメーションを管理するスクリプト
    public AnimationController anim;
   

    //接地フラグ入れる変数
    bool isGroudFlg = false;
    //ターン可能な地面との設置フラグを入れる
    bool isTurnGroundFlg = false;

    //プレイヤーの落下判定のy座標ボーダー
    float playerFallBorder_y = -2.0f;

    //現在の入力状態を入れる変数
    ScreenInput.FlickDirection nowFlick;
    //現在のプレイヤー状態を入れる変数
    Status.PlayerSituation nowSituation;
    //現在のプレイヤーの生死状態を入れる変数
    Status.PlayerSurvival nowSurvival;
    //現在のプレイヤーの向いてる方向を入れる変数
    Status.PlayerDirection nowDirection;
    //現在のプレイヤーの座標を入れる変数
    Vector3 nowPosition;

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
        this.isTurnGroundFlg = this.ground.GetTurnGroundStandFlg();


        //フリック方向を受け取る
        this.nowFlick = this.screenInput.GetNowFlick();
        //現在の状態を受け取る
        this.nowSituation = this.status.GetNowPlayerSituation();
        //現在の生死状態を受け取る
        this.nowSurvival = this.status.GetNowPlayerSurvival();
        //現在のプレイヤーの向いてる方向を受け取る
        this.nowDirection = this.status.GetNowPlayerDirection();

        //ステータスの更新
        this.status.SituationUpdate(this.isGroudFlg, this.nowFlick, this.isTurnGroundFlg);
        //移動の更新
        this.move.MovePlayerUpdate(this.nowFlick, this.nowSituation, this.nowDirection , this.isGroudFlg);
        //アニメーション更新
        this.anim.AnimationUpdate(this.nowFlick, this.nowSituation);

        
    }

    
}
