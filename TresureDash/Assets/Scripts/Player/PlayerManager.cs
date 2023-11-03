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
    [Tooltip("接地判定のオブジェクト")][SerializeField] 
    GroudCheck groundCheck_object;

    [Tooltip("プレイヤーの衝突チェックオブジェクト")][SerializeField] 
    CollisionCheck collisionCheck_object;

    [Tooltip("入力状態を返すオブジェクト")][SerializeField]
    ScreenInput screenInput_object;    

    [Tooltip("ジャイロ入力を返すオブジェクト")][SerializeField] 
    GyroInput gyroInput_object;

    [Tooltip("プレイヤー状態を管理オブジェクト")][SerializeField] 
    Status playerStatus_object; 
    
    [Tooltip("プレイヤーを動かすオブジェクト")][SerializeField]
    Move playerMove_object;    

    [Tooltip("アニメーションを管理するオブジェクト")][SerializeField] 
    PlayerAnimationController playerAnimation_object;

    [Tooltip("プレイヤーのサウンドを管理するオブジェクト")][SerializeField] 
    SoundController playerSound_object;    

    [Tooltip("シーンのコントローラーオブジェクト")][SerializeField]
    SceneChenger sceneController_object;  
    
    [Tooltip("プレイヤーのパーティクルコントローラーオブジェクト")][SerializeField]
    ParticleController particleController_object;

    [Tooltip("接地フラグ")]
    bool onGroudFlg = false;
    // ターン可能な地面との設置フラグを入れる
    [Tooltip("ターン可能な地面との接地フラグ")]
    bool onTurnGroundFlg = false;

    [Tooltip("現在の入力状態を入れる変数")]
    ScreenInput.FlickDirection currentFlick;

    [Tooltip("スマホの傾きを入れる変数")]
    GyroInput.TiltDirection currentTili_direction;

    [Tooltip("プレイヤーの状態を入れる変数")]
    Status.PlayerState currentSituation;
    
    [Tooltip("現在のプレイヤーの生死状態を入れる変数")]
    Status.PlayerAlive currentAlive;

    [Tooltip("現在のプレイヤーの向いてる方向を入れる変数")]
    Status.PlayerDirection currentDirection;

    [Tooltip("落下死の待機時間定数")]
    const float FallDeathWaitTime = 1.0f;
    [Tooltip("衝突死の待機時間定数")]
    const float CollisionDeathWaitTImer = 2.1f;
    [Tooltip("ゴール時の待機時間定数")]
    const float GoalWaitTimer = 3.0f;

    //プレイヤーのフラグ
    bool collisionFlg = false;
    bool deathFlg =     false;
    
    [Tooltip("タイトルシーン切り替えのデリゲート")]
    SceneChenger.changeScene_delegate change_ResultScene_delegate;

    [Tooltip("落下音再生のデリゲート")]
    SoundController.ply_playerSound_delegate player_fallSound_delegate;

    [Tooltip("衝突音再生のデリゲート")]
    SoundController.ply_playerSound_delegate player_collisionSound_delegate;

    [Tooltip("ジャンプ音再生のデリゲート")]
    SoundController.ply_playerSound_delegate player_jumpound_delegate;

    void Awake()
    {
        // コルーチン呼び出し
        StartCoroutine(playerStatus_object.ChangeSituation());
        StartCoroutine(playerAnimation_object.ChangeAnimaiton());

        // タイトルシーンへの切り替えメソッドをchange_ResultScene_delegateへ代入
        this.change_ResultScene_delegate = new 
        SceneChenger.changeScene_delegate(this.sceneController_object.ChangeResultScene);

        // 落下音の再生メソッドをplayer_fallSound_delegateへ代入
        this.player_fallSound_delegate = new 
        SoundController.ply_playerSound_delegate(this.playerSound_object.PlyFallSound);

        // 衝突音再生メソッドを
        this.player_collisionSound_delegate = new 
        SoundController.ply_playerSound_delegate(this.playerSound_object.PlyCollisionSound);

        // ジャンプ音の再生メソッドをplayer_jumpound_delegateへ代入
        this.player_jumpound_delegate = new 
        SoundController.ply_playerSound_delegate(this.playerSound_object.PlyJumpSound);
    }

    void Update()
    {
        // 接地判定を受け取る
        this.onGroudFlg      = this.groundCheck_object.GetGroundStandFlg();
        this.onTurnGroundFlg = this.groundCheck_object.GetTurnGroundStandFlg();

        // フリック方向を受け取る
        this.currentFlick          = this.screenInput_object.GetNowFlick();
        // スマホの傾きを受け取る
        this.currentTili_direction = this.gyroInput_object.GetDifferenceTilt();
        // 現在の状態を受け取る
        this.currentSituation      = this.playerStatus_object.GetNowPlayerSituation();
        // 現在の生死状態を受け取る
        this.currentAlive          = this.playerStatus_object.GetNowPlayerSurvival();
        // 現在のプレイヤーの向いてる方向を受け取る
        this.currentDirection      = this.playerStatus_object.GetNowPlayerDirection();
        // レイヤーの衝突フラグを受け取る
        this.collisionFlg          = this.collisionCheck_object.GetCollisionFlg();

        // プレイヤーが生存状態での処理
        if(this.currentAlive == Status.PlayerAlive.Life)
        {
            // ステータスの更新
            this.playerStatus_object.SituationUpdate(this.onGroudFlg, this.currentFlick, this.onTurnGroundFlg);
            // 移動の更新
            this.playerMove_object.MovePlayerUpdate(this.currentFlick, this.currentSituation, this.currentDirection, this.currentTili_direction, this.onTurnGroundFlg,this.player_jumpound_delegate);
            // アニメーション更新
            this.playerAnimation_object.AnimationUpdate(this.currentFlick, this.currentSituation, this.collisionFlg);
            // プレイヤーの生死確認
            this.playerStatus_object.SurvivalChek(this.collisionFlg);
            // プレイヤーの移動サウンド再生
            this.playerSound_object.PlyWalkSound(this.currentSituation);
        }

        // 衝突死の処理
        if(this.currentAlive == Status.PlayerAlive.CollisionDeath && !this.deathFlg)
        {            
            // 衝突パーティクル再生
            this.particleController_object.PlyCollisionParticle();
            // 衝突音再生
            this.player_collisionSound_delegate();
            // デリゲートでシーンをリザルトに変更
            StartCoroutine(this.change_ResultScene_delegate(CollisionDeathWaitTImer));

            // 死亡フラグを立てる
            this.deathFlg = true;
        }

        // 落下死処理
        if(this.currentAlive == Status.PlayerAlive.FallDeath && !this.deathFlg)
        {
            // 落下サウンド再生
            this.player_fallSound_delegate();
            // デリゲートでシーンをリザルトに変更
            StartCoroutine(this.change_ResultScene_delegate(FallDeathWaitTime));

            // 死亡フラグを立てる
            this.deathFlg = true;
        }
    }

    /// <summary>
    /// アイテムが獲得した報告を受け取りサウンド再生命令
    /// </summary>
    /// <param name="itemPos">獲得したアイテムの座標</param>
    public void ItemGetReport(Vector3 itemPos)
    {
        // 獲得音再生の命令
        this.playerSound_object.PlyGetItemSound();
        // 獲得時kのパーティクル再生
        this.particleController_object.PlyItemGetParticle(itemPos);
    }

    /// <summary>
    /// プレイヤーがゴールした報告を受けとる
    /// </summary>
    public void GoalReport()
    {
        // デリゲートでリザルトシーンへの切り替え
        StartCoroutine(this.change_ResultScene_delegate(GoalWaitTimer));
        // アニメーショントリガーを切り替える
        this.playerAnimation_object.ChangeTrigger_Goal();
        // ゴール音再生命令
        this.playerSound_object.PlyGoalSound();
        // 生存状態を切り替える
        this.playerStatus_object.ChangeNowSurvival_Goal();
    }
}
