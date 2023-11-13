using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// プレイヤーを管理するマネージャークラス
/// </summary>
public class PlayerManager : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] GroudCheck                groundCheck;        // プレイヤーの接地判定クラス
    [SerializeField] CollisionCheck            collisionCheck;     // プレイヤーの衝突管理クラス
    [SerializeField] Status                    playerState;        // プレイヤーの状態管理クラス     
    [SerializeField] PlayerMove                playerMove;         // プレイヤーの動きを管理するクラス
    [SerializeField] PlayerAnimationController playerAnimation;    // プレイヤーのアニメーション管理クラス
    [SerializeField] SoundController           playerSound;        // プレイヤーのサウンド管理クラス
    [SerializeField] ParticleController        particleController; // プレイヤーのパーティクルコントローラークラス
    [SerializeField] SceneChenger              sceneController;    // シーンのコントローラークラス
    [SerializeField] ScreenInput               screenInput;        // タップ入力感知クラス
    [SerializeField] GyroInput                 gyroInput;          // ジャイロ入力感知クラス

    ScreenInput.FlickDirection nowFlick;          // 現在の入力状態を入れる変数
    ScreenInput.BufferedFlick  nowBufferedFlick;  // 現在の先行入力状態を入れる変数
    GyroInput.TiltDirection    nowTili_direction; // スマホの傾きを入れる変数
    Status.PlayerState         nowSituation;      // プレイヤーの状態を入れる変数
    Status.PlayerAlive         nowAlive;          // 現在のプレイヤーの生死状態を入れる変数
    Status.PlayerDirection     nowDirection;      // 現在のプレイヤーの向いてる方向を入れる変数

    // フラグ
    bool onGroudFlg      = false; // 接地フラグ
    bool onTurnGroundFlg = false; // ターン可能な地面との設置フラグを入れる
    bool collisionFlg    = false; // プレイヤーの衝突フラグ
    bool deathFlg        = false; // プレイヤーの死亡フラグ

    // 定数
    const float FallDeathWaitTime       = 1.0f; // 落下死の待機時間
    const float CollisionDeathWaitTImer = 2.1f; // 衝突死の待機時間
    const float GoalWaitTimer           = 3.0f; // ゴール時の待機時間

    // デリゲート
    SceneChenger.changeScene_delegate        ChangeResultScene;    // タイトルシーン切り替えのデリゲート
    SoundController.PlyPlayerSound PlayerFallSound;      // 落下音再生のデリゲート
    SoundController.PlyPlayerSound PlayerCollisionSound; // 衝突音再生のデリゲート
    SoundController.PlyPlayerSound PlayJumpoSound;       // ジャンプ音再生のデリゲート

    void Awake()
    {
        // コルーチン呼び出し
        StartCoroutine(playerState.ChangeSituation());
        StartCoroutine(playerAnimation.ChangeAnimaiton());

        // タイトルシーンへの切り替えメソッドをchange_ResultScene_delegateへ代入
        ChangeResultScene = new 
        SceneChenger.changeScene_delegate(sceneController.ChangeResultScene);

        // 落下音の再生メソッドをplayer_fallSound_delegateへ代入
        PlayerFallSound = new 
        SoundController.PlyPlayerSound(playerSound.PlyFallSound);

        // 衝突音再生メソッドを
        PlayerCollisionSound = new 
        SoundController.PlyPlayerSound(playerSound.PlyCollisionSound);

        // ジャンプ音の再生メソッドをplayer_jumpound_delegateへ代入
        PlayJumpoSound = new 
        SoundController.PlyPlayerSound(playerSound.PlyJumpSound);

        // イベントリストのセット
        collisionCheck.SetEventList(screenInput.GetEventList());
    }

    void Update()
    {
        // 必要情報を取得
        onGroudFlg        = groundCheck.GetGroundStandFlg();     // 接地判定を受け取る
        onTurnGroundFlg   = groundCheck.GetTurnGroundStandFlg(); // 回転地面接地判定を受け取る  
        nowFlick          = screenInput.GetNowFlick();           // フリック方向を受け取る        
        nowBufferedFlick  = screenInput.GetNowBufferedFLick();   // 先行入力を受け取る        
        nowTili_direction = gyroInput.GetDifferenceTilt();       // スマホの傾きを受け取る       
        nowSituation      = playerState.GetNowPlayerSituation(); // 現在の状態を受け取る     
        nowAlive          = playerState.GetNowPlayerSurvival();  // 現在の生死状態を受け取る       
        nowDirection      = playerState.GetNowPlayerDirection(); // 現在のプレイヤーの向いてる方向を受け取る
        collisionFlg      = collisionCheck.GetCollisionFlg();    // プレイヤーの衝突フラグを受け取る

        // プレイヤーが生存状態での処理
        if (nowAlive == Status.PlayerAlive.Life)
        {
            // ステータスの更新
            playerState.SituationUpdate(onGroudFlg, nowFlick, onTurnGroundFlg, nowBufferedFlick);
            // 移動の更新
            playerMove.UpdatePlayerMove(nowFlick, nowSituation, nowDirection, nowTili_direction, onTurnGroundFlg,PlayJumpoSound);
            // アニメーション更新
            playerAnimation.AnimationUpdate(nowFlick, nowSituation, collisionFlg);
            // プレイヤーの生死確認
            playerState.SurvivalChek(collisionFlg);
            // プレイヤーの移動サウンド再生
            playerSound.PlyWalkSound(nowSituation);
        }

        // 衝突死の処理
        if(nowAlive == Status.PlayerAlive.CollisionDeath && !deathFlg)
        {            
            // 衝突パーティクル再生
            particleController.PlyCollisionParticle();
            // 衝突音再生
            PlayerCollisionSound();
            // デリゲートでシーンをリザルトに変更
            StartCoroutine(ChangeResultScene(CollisionDeathWaitTImer));

            // 死亡フラグを立てる
            deathFlg = true;
        }

        // 落下死処理
        if(nowAlive == Status.PlayerAlive.FallDeath && !deathFlg)
        {
            // 落下サウンド再生
            PlayerFallSound();
            // デリゲートでシーンをリザルトに変更
            StartCoroutine(ChangeResultScene(FallDeathWaitTime));

            // 死亡フラグを立てる
            deathFlg = true;
        }
    }

    /// <summary>
    /// アイテムが獲得した報告を受け取りサウンド再生命令
    /// </summary>
    /// <param name="itemPos">獲得したアイテムの座標</param>
    public void ItemGetReport(Vector3 itemPos)
    {
        // 獲得音再生の命令
        playerSound.PlyGetItemSound();
        // 獲得時kのパーティクル再生
        particleController.PlyItemGetParticle(itemPos);
    }

    /// <summary>
    /// プレイヤーがゴールした報告を受けとる
    /// </summary>
    public void GoalReport()
    {
        // デリゲートでリザルトシーンへの切り替え
        StartCoroutine(ChangeResultScene(GoalWaitTimer));
        // アニメーショントリガーを切り替える
        playerAnimation.ChangeTrigger_Goal();
        // ゴール音再生命令
        playerSound.PlyGoalSound();
        // 生存状態を切り替える
        playerState.ChangeNowSurvival_Goal();
    }
}
