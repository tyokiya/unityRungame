using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// プレイヤーを管理するマネージャースクリプト
////////////////////////////////////
public class PlayerManager : MonoBehaviour
{
    //インスペクターから設定
    //接地判定のオブジェクト
    public GroudCheck groundCheck_object;
    //入力状態を返すオブジェクト
    public ScreenInput screenInput_object;
    //現在のプレイヤー状態を管理オブジェクト
    public Status playerStatus_object;
    //プレイヤーを動かすオブジェクト
    public Move playerMove_object;
    //アニメーションを管理するオブジェクト
    public AnimationController playerAnimation_object;
   

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
        StartCoroutine(playerStatus_object.ChangeSituation());
        StartCoroutine(playerAnimation_object.ChangeAnimaiton());
    }

    void Update()
    {
        //接地判定を受け取る
        this.isGroudFlg = this.groundCheck_object.GetGroundStandFlg();
        this.isTurnGroundFlg = this.groundCheck_object.GetTurnGroundStandFlg();

        //フリック方向を受け取る
        this.nowFlick = this.screenInput_object.GetNowFlick();
        //現在の状態を受け取る
        this.nowSituation = this.playerStatus_object.GetNowPlayerSituation();
        //現在の生死状態を受け取る
        this.nowSurvival = this.playerStatus_object.GetNowPlayerSurvival();
        //現在のプレイヤーの向いてる方向を受け取る
        this.nowDirection = this.playerStatus_object.GetNowPlayerDirection();

        //ステータスの更新
        this.playerStatus_object.SituationUpdate(this.isGroudFlg, this.nowFlick, this.isTurnGroundFlg);
        //移動の更新
        this.playerMove_object.MovePlayerUpdate(this.nowFlick, this.nowSituation, this.nowDirection , this.isGroudFlg);
        //アニメーション更新
        this.playerAnimation_object.AnimationUpdate(this.nowFlick, this.nowSituation);
    }
}
