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
    [SerializeField] GroudCheck groundCheck_object;
    //入力状態を返すオブジェクト
    [SerializeField] ScreenInput screenInput_object;
    //ジャイロ入力を返すオブジェクト
    [SerializeField] GyroInput gyroInput_object;
    //現在のプレイヤー状態を管理オブジェクト
    [SerializeField] Status playerStatus_object;
    //プレイヤーを動かすオブジェクト
    [SerializeField] Move playerMove_object;
    //アニメーションを管理するオブジェクト
    [SerializeField] AnimationController playerAnimation_object;
    //プレイヤーのサウンドを管理するオブジェクト
    [SerializeField] SoundController playerSound_object;
    //シーンのコントローラーオブジェクト
    [SerializeField] SceneController sceneController_object;

    //接地フラグ入れる変数
    bool isGroudFlg = false;
    //ターン可能な地面との設置フラグを入れる
    bool isTurnGroundFlg = false;

    //現在の入力状態を入れる変数
    ScreenInput.FlickDirection nowFlick;
    //スマホの傾きを入れる変数
    float difference_tilt;
    //現在のプレイヤー状態を入れる変数
    Status.PlayerSituation nowSituation;
    //現在のプレイヤーの生死状態を入れる変数
    Status.PlayerSurvival nowSurvival;
    //現在のプレイヤーの向いてる方向を入れる変数
    Status.PlayerDirection nowDirection;

    
    //タイトルシーン切り替えのデリゲート
    SceneController.changeScene_delegate change_ResultScene_delegate;

    //落下音再生のデリゲート
    SoundController.ply_playerSound_delegate player_fallSound_delegate;
    void Awake()
    {
        //コルーチン呼び出し
        StartCoroutine(playerStatus_object.ChangeSituation());
        StartCoroutine(playerAnimation_object.ChangeAnimaiton());

        //タイトルシーンへの切り替えメソッドをchange_ResultScene_delegateへ代入
        change_ResultScene_delegate = new SceneController.changeScene_delegate(sceneController_object.ChangeResultScene);
        //落下音の再生メソッドをplayer_fallSound_delegateへ代入
        player_fallSound_delegate = new SoundController.ply_playerSound_delegate(playerSound_object.PlyFallSound);
    }

    void Update()
    {
        //接地判定を受け取る
        this.isGroudFlg = this.groundCheck_object.GetGroundStandFlg();
        this.isTurnGroundFlg = this.groundCheck_object.GetTurnGroundStandFlg();

        //フリック方向を受け取る
        this.nowFlick = this.screenInput_object.GetNowFlick();
        //スマホの傾きを受け取る
        this.difference_tilt = this.gyroInput_object.GetDifferenceTilt();
        //現在の状態を受け取る
        this.nowSituation = this.playerStatus_object.GetNowPlayerSituation();
        //現在の生死状態を受け取る
        this.nowSurvival = this.playerStatus_object.GetNowPlayerSurvival();
        //現在のプレイヤーの向いてる方向を受け取る
        this.nowDirection = this.playerStatus_object.GetNowPlayerDirection();

        //プレイヤーが生存状態での処理
        if(this.nowSurvival == Status.PlayerSurvival.life)
        {
            //ステータスの更新
            this.playerStatus_object.SituationUpdate(this.isGroudFlg, this.nowFlick, this.isTurnGroundFlg);
            //移動の更新
            this.playerMove_object.MovePlayerUpdate(this.nowFlick, this.nowSituation, this.nowDirection, this.difference_tilt, this.isTurnGroundFlg);
            //アニメーション更新
            this.playerAnimation_object.AnimationUpdate(this.nowFlick, this.nowSituation);
            //プレイヤーの落下確認
            this.playerStatus_object.FallChek(this.change_ResultScene_delegate, this.player_fallSound_delegate);
            //プレイヤーの移動サウンド再生
            this.playerSound_object.PlyWalkSound(this.nowSituation);
        }
        
       
    }
}
