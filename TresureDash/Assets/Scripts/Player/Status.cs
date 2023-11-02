using System.Collections;
using UnityEngine;

////////////////////////////////////
// プレイヤーのステータスを管理するスクリプト
////////////////////////////////////

public class Status : MonoBehaviour
{
    //インスペクターから設定
    [Tooltip("親オブジェクトのトランスフォーム")][SerializeField]
    Transform parent_transform;

    //プレイヤーの落下判定のボーダーラインY軸
    const float PlayerFallBorder_y = -0.5f;

    [Tooltip("方向回転のデルタタイム")]
    float rotationDelta = 0;
    [Tooltip("方向回転のスパン定数")]
    const float RotationSpan = 1.0f;

    [Tooltip("状態切り替えの待機時間")]
    float waitTime = 3.0f;

    [Tooltip("プレイヤーの状態")]
    public enum PlayerState
    {
        walk,
        run,
        jump
    }
    PlayerState currentSituation = PlayerState.walk;
    
    [Tooltip("プレイヤーの生死状態")]
    public enum PlayerAlive
    {
        life,                   //生存状態
        collisionDeath,         //衝突による死亡状態
        fallDeath,              //落下による死亡状態
        clearLife               //生存状態でのクリア
    }
    PlayerAlive currentAlive = PlayerAlive.life;

    [Tooltip("現在のプレイヤー向いている方向")]
    public enum PlayerDirection
    {
        front,
        right,
        back,
        left
    }
    PlayerDirection currentDirection = PlayerDirection.front;

    void Update()
    {
        //デルタ増加
        this.rotationDelta += Time.deltaTime;
    }

    /// <summary>
    /// 3秒後状態を切りかえるコルーチン
    /// </summary>
    public IEnumerator ChangeSituation()
    {
        //3秒待機
        yield return new WaitForSeconds(this.waitTime);
        //Debug.Log("ステータスコルーチン実行");
        //状態を切り替え
        this.currentSituation = PlayerState.run;
    }

    /// <summary>
    /// 現在のプレイヤーの状態を返す
    /// </summary>
    public PlayerState GetNowPlayerSituation()
    {
        return this.currentSituation;
    }

    /// <summary>
    /// 現在のプレイヤーの方向を返す
    /// </summary>
    public PlayerDirection GetNowPlayerDirection()
    {
        return this.currentDirection;
    }

    /// <summary>
    /// 現在のプレイヤーの生死状態を返す
    /// </summary>
    public PlayerAlive GetNowPlayerSurvival()
    {
        return this.currentAlive;
    }

    /// <summary>
    /// 状態を接地状態に応じて更新する
    /// </summary>
    /// <param name="GroundFlg">接地フラグ</param>
    /// <param name="flick">現在の入力状態</param>
    /// <param name="turnGroundFlg">ターン可能な地面との接地フラグ</param>
    public void SituationUpdate(bool GroundFlg, ScreenInput.FlickDirection flick, bool turnGroundFlg)
    {
        //ジャンプ状態から地面についた場合ステータスを変更
        if (GroundFlg && this.currentSituation == PlayerState.jump)
        {
            this.currentSituation = PlayerState.run;
        }

        //フリックの状態に応じてステータスを変更
        //プレイヤーが走っている状態のときはジャンプに切り替える
        if (flick == ScreenInput.FlickDirection.UP && this.currentSituation == PlayerState.run)
        {
            this.currentSituation = PlayerState.jump;
        }

        //向きを変える処理
        //ターン可能な地面にいるかの確認
        //走り状態化の確認
        if (flick == ScreenInput.FlickDirection.RIGHT && this.rotationDelta > RotationSpan && currentSituation == PlayerState.run && turnGroundFlg)
        {
            ChangeDirection(true);
            //デルタ初期化
            this.rotationDelta = 0;
        }
        if (flick == ScreenInput.FlickDirection.LEFT && this.rotationDelta > RotationSpan && currentSituation == PlayerState.run && turnGroundFlg)
        {
            ChangeDirection(false);
            //デルタ初期化
            this.rotationDelta = 0;
        }

    }

    /// <summary>
    /// プレイヤーの方向を変える
    /// </summary>
    /// <param name="rightFlg">右向き回転のフラグ</param>
    void ChangeDirection(bool rightFlg)
    {
        //現在の方向と回転方向に応じた処理
        switch (this.currentDirection)
        {
            case PlayerDirection.front:
                if (rightFlg)
                {
                    this.currentDirection = PlayerDirection.right;
                    //Debug.Log("プレイヤーの方向変更(右)");
                }
                else
                {
                    this.currentDirection = PlayerDirection.left;
                    //Debug.Log("プレイヤーの方向変更(左)");
                }
                break;
            case PlayerDirection.right:
                if (rightFlg)
                {
                    this.currentDirection = PlayerDirection.back;
                    //Debug.Log("プレイヤーの方向変更(後)");
                }
                else
                {
                    this.currentDirection = PlayerDirection.front;
                    //Debug.Log("プレイヤーの方向変更(前)");
                }
                break;
            case PlayerDirection.back:
                if (rightFlg)
                {
                    this.currentDirection = PlayerDirection.left;
                    //Debug.Log("プレイヤーの方向変更(左)");
                }
                else
                {
                    this.currentDirection = PlayerDirection.right;
                    //Debug.Log("プレイヤーの方向変更(右)");
                }
                break;
            case PlayerDirection.left:
                if (rightFlg)
                {
                    this.currentDirection = PlayerDirection.front;
                    //Debug.Log("プレイヤーの方向変更(前)");
                }
                else
                {
                    this.currentDirection = PlayerDirection.back;
                    //Debug.Log("プレイヤーの方向変更(後)");
                }
                break;
        }

    }

    /// <summary>
    /// プレイヤーの生死判定
    /// </summary>
    /// <param name="changeScene_delegate">リザルトシーンへの切り替えデリゲート</param>
    /// <param name="ply_fallSound_delegate">落下音再生のデリゲート</param>
    /// <param name="collisionFlg">プレイヤーの衝突フラグ</param>
    /// <param name="ply_collision_delegate">衝突音再生のデリゲート</param>
    public void SurvivalChek(bool collisionFlg)
    {
        //プレヤーの座標が落下ボーダーより下にないかの確認
        if (parent_transform.position.y < PlayerFallBorder_y)
        {
            //プレイヤーの生存状態を変更
            this.currentAlive = PlayerAlive.fallDeath;
        }
        //衝突フラグが立っているかを確認
        if (collisionFlg)
        {
            //プレイヤーの生存状態を変更
            this.currentAlive = PlayerAlive.collisionDeath;
        }
    }

    /// <summary>
    /// 現在のプレイヤーの状態をゴール状態にする
    /// </summary>
    public void ChangeNowSurvival_Goal()
    {
        this.currentAlive = PlayerAlive.clearLife;
    }
}
