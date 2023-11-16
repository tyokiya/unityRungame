using System.Collections;
using UnityEngine;

/// <summary>
/// プレイヤーの状態を管理するクラス
/// </summary>
public class Status : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] Transform parentTransform; // 親オブジェクトのトランスフォーム

    // 方向回転のデルタタイム
    float rotationDelta = 0;

    // 定数
    const float PlayerFallBorder_y  = -0.5f; // プレイヤーの落下判定のボーダーラインY軸
    const float RotationSpan        = 1.0f;  // 方向回転のスパン定数
    const float ChangeStateWaitTime = 3.0f;  // 状態切り替えの待機時間

    public enum PlayerState
    {
        Walk,
        Run,
        Jump
    }
    PlayerState currentSituation = PlayerState.Walk; // プレイヤーの状態

    public enum PlayerAlive
    {
        Life,           //生存状態
        CollisionDeath, //衝突による死亡状態
        FallDeath,      //落下による死亡状態
        ClearLife       //生存状態でのクリア
    }
    PlayerAlive currentAlive = PlayerAlive.Life; // プレイヤーの生死状態

    public enum PlayerDirection
    {
        Front,
        Right,
        Back,
        Left
    }
    PlayerDirection currentDirection = PlayerDirection.Front; // 現在のプレイヤー向いている方向

    void Update()
    {
        //デルタ増加
        rotationDelta += Time.deltaTime;
    }

    /// <summary>
    /// 3秒後状態を切りかえるコルーチン
    /// </summary>
    public IEnumerator ChangeSituation()
    {
        // 3秒待機
        yield return new WaitForSeconds(ChangeStateWaitTime);
        //Debug.Log("ステータスコルーチン実行");
        // 状態を切り替え
        currentSituation = PlayerState.Run;
    }

    /// <summary>
    /// 現在のプレイヤーの状態を返す
    /// </summary>
    public PlayerState GetNowPlayerSituation()
    {
        return currentSituation;
    }

    /// <summary>
    /// 現在のプレイヤーの方向を返す
    /// </summary>
    public PlayerDirection GetNowPlayerDirection()
    {
        return currentDirection;
    }

    /// <summary>
    /// 現在のプレイヤーの生死状態を返す
    /// </summary>
    public PlayerAlive GetNowPlayerSurvival()
    {
        return currentAlive;
    }

    /// <summary>
    /// 状態を接地状態に応じて更新する
    /// </summary>
    /// <param name="GroundFlg">接地フラグ</param>
    /// <param name="flick">現在の入力状態</param>
    /// <param name="turnGroundFlg">ターン可能な地面との接地フラグ</param>
    /// <param name="bufferedFlick">先行入力のフリック方向</param>
    public void SituationUpdate(bool GroundFlg, ScreenInput.FlickDirection flick, bool turnGroundFlg, ScreenInput.BufferedFlick bufferedFlick)
    { 
        // ジャンプ状態から地面についた場合ステータスを変更
        if (GroundFlg && currentSituation == PlayerState.Jump)
        {
            currentSituation = PlayerState.Run;
        }

        // フリックの状態に応じてステータスを変更
        // プレイヤーが走っている状態のときはジャンプに切り替える
        if (flick == ScreenInput.FlickDirection.UP && currentSituation == PlayerState.Run)
        {
            currentSituation = PlayerState.Jump;
        }

        // 向きを変える処理
        // ターン可能な地面にいるかの確認
        // 走り状態化の確認
        if (bufferedFlick == ScreenInput.BufferedFlick.RIGHT && rotationDelta > RotationSpan && currentSituation == PlayerState.Run && turnGroundFlg)
        {
            ChangeDirection(true);
            // デルタ初期化
            rotationDelta = 0;
        }
        if (bufferedFlick == ScreenInput.BufferedFlick.LEFT && rotationDelta > RotationSpan && currentSituation == PlayerState.Run && turnGroundFlg)
        {
            ChangeDirection(false);
            // デルタ初期化
            rotationDelta = 0;
        }

    }

    /// <summary>
    /// プレイヤーの方向を変える
    /// </summary>
    /// <param name="rightFlg">右向き回転のフラグ</param>
    void ChangeDirection(bool rightFlg)
    {
        // 現在の方向と回転方向に応じた処理
        switch (currentDirection)
        {
            case PlayerDirection.Front:
                if (rightFlg)
                {
                    currentDirection = PlayerDirection.Right;
                    //Debug.Log("プレイヤーの方向変更(右)");
                }
                else
                {
                    currentDirection = PlayerDirection.Left;
                    //Debug.Log("プレイヤーの方向変更(左)");
                }
                break;
            case PlayerDirection.Right:
                if (rightFlg)
                {
                    currentDirection = PlayerDirection.Back;
                    //Debug.Log("プレイヤーの方向変更(後)");
                }
                else
                {
                    currentDirection = PlayerDirection.Front;
                    //Debug.Log("プレイヤーの方向変更(前)");
                }
                break;
            case PlayerDirection.Back:
                if (rightFlg)
                {
                    currentDirection = PlayerDirection.Left;
                    //Debug.Log("プレイヤーの方向変更(左)");
                }
                else
                {
                    currentDirection = PlayerDirection.Right;
                    //Debug.Log("プレイヤーの方向変更(右)");
                }
                break;
            case PlayerDirection.Left:
                if (rightFlg)
                {
                    currentDirection = PlayerDirection.Front;
                    //Debug.Log("プレイヤーの方向変更(前)");
                }
                else
                {
                    currentDirection = PlayerDirection.Back;
                    //Debug.Log("プレイヤーの方向変更(後)");
                }
                break;
        }

    }

    /// <summary>
    /// プレイヤーの生死判定
    /// </summary>
    /// <param name="collisionFlg">プレイヤーの衝突フラグ</param>
    public void SurvivalChek(bool collisionFlg)
    { 
        // プレヤーの座標が落下ボーダーより下にないかの確認
        if (parentTransform.position.y < PlayerFallBorder_y)
        {
            // プレイヤーの生存状態を変更
            currentAlive = PlayerAlive.FallDeath;
        }
        // 衝突フラグが立っているかを確認
        if (collisionFlg)
        {
            //プレイヤーの生存状態を変更
            currentAlive = PlayerAlive.CollisionDeath;
        }
    }

    /// <summary>
    /// 現在のプレイヤーの状態をゴール状態にする
    /// </summary>
    public void ChangeNowSurvival_Goal()
    {
        currentAlive = PlayerAlive.ClearLife;
    }
}
