using UnityEngine;
using static Status;

/// <summary>
/// カメラのコントローラークラス
/// </summary>
public class CameraController : MonoBehaviour
{
    [Tooltip("カメラの振り向き速度定数")]
    const float TurnAngleSpeed = 9.0f;
    [Tooltip("カメラの回転時の移動速度定数")]
    const float AngularVelocity = 0.6f;

    [Tooltip("プレイヤーとカメラの距離定数")]
    const float PlayerDirection = 5.0f;

    [Tooltip("振り向きの最大回数の定数")]
    const int MaxTurnCnt = 10;

    [Tooltip("変更前のプレイヤーの向き")]
    PlayerDirection beforeDirection = Status.PlayerDirection.Front;

    [Tooltip("角度に加算した回数のカウンタ")]
    int turnCnt = 0;

    /// <summary>
    /// カメラの情報更新
    /// </summary>
    /// <param name="playerPos">現在のプレイヤーの座標</param>
    /// <param name="currentDirection">現在のプレイヤーの向いてる方向</param>
    /// <param name="state">現在のプレイヤーの状態</param>
    public void UpdateCamera(Vector3 playerPos, PlayerDirection currentDirection, PlayerState state)
    {
        // プレイヤーの向いてる方向に変更があったら
        // カメラの向きを変える(走り出して以降)
        if(state == PlayerState.Run && currentDirection != this.beforeDirection)
        {
            RotationCamera(currentDirection);
        }
        else
        {
            // プレイヤーの向いてる方向をもとに
            // 常に一定の距離を保ちながらプレイヤーを追従
            MoveCamera(playerPos, currentDirection, state);
        }        
    }

    /// <summary>
    /// カメラの向き回転処理
    /// </summary>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    void RotationCamera(PlayerDirection direction)
    {
        // カウント増加
        this.turnCnt++;

        // プレイヤーの向いてる方向に合わせてカメラの回転処理
        switch (direction)
        {
            case Status.PlayerDirection.Front:
                // 前を向かせる　
                if (this.beforeDirection == Status.PlayerDirection.Left)
                {
                    transform.eulerAngles += new Vector3(0, TurnAngleSpeed, 0);
                    transform.position += new Vector3(-AngularVelocity, 0, -AngularVelocity);
                }
                else if (this.beforeDirection == Status.PlayerDirection.Right)
                {
                    transform.eulerAngles -= new Vector3(0, TurnAngleSpeed, 0);
                    transform.position += new Vector3(AngularVelocity, 0, -AngularVelocity);
                }
                break;
            case Status.PlayerDirection.Right:
                // 右を向かせる　
                if(this.beforeDirection == Status.PlayerDirection.Front)
                {
                    transform.eulerAngles += new Vector3(0, TurnAngleSpeed, 0);
                    transform.position += new Vector3(-AngularVelocity, 0, AngularVelocity);
                }
                else if(this.beforeDirection == Status.PlayerDirection.Back)
                {
                    transform.eulerAngles -= new Vector3(0, TurnAngleSpeed, 0);
                    transform.position += new Vector3(-AngularVelocity, 0, -AngularVelocity);
                }
                break;
            case Status.PlayerDirection.Back:
                // 後を向かせる　
                if (this.beforeDirection == Status.PlayerDirection.Right)
                {
                    transform.eulerAngles += new Vector3(0, TurnAngleSpeed, 0);
                    transform.position += new Vector3(AngularVelocity, 0, AngularVelocity);
                }
                else if (this.beforeDirection == Status.PlayerDirection.Left)
                {
                    transform.eulerAngles -= new Vector3(0, TurnAngleSpeed, 0);
                    transform.position += new Vector3(-AngularVelocity, 0, AngularVelocity);
                }
                break;
            case Status.PlayerDirection.Left:
                // 左を向かせる　
                if (this.beforeDirection == Status.PlayerDirection.Back)
                {
                    transform.eulerAngles += new Vector3(0, TurnAngleSpeed, 0);
                    transform.position += new Vector3(AngularVelocity, 0, -AngularVelocity);
                }
                else if (this.beforeDirection == Status.PlayerDirection.Front)
                {
                    transform.eulerAngles -= new Vector3(0, TurnAngleSpeed, 0);
                    transform.position += new Vector3(AngularVelocity, 0, AngularVelocity);
                }
                break;
        }
        // カウントが30回になったら回転処理完了
        // プレイヤーの変更前の向きを更新
        if (this.turnCnt == MaxTurnCnt)
        {
            this.beforeDirection = direction;
            // カウント初期化
            this.turnCnt = 0;
        }
    }

    /// <summary>
    /// カメラの追従処理
    /// </summary>
    /// <param name="playerPos">現在のプレイヤーの座標</param>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    /// <param name="state">プレイヤーの状態</param>
    void MoveCamera(Vector3 playerPos, PlayerDirection direction, PlayerState state)
    {
        if(state == PlayerState.Walk)
        {
            transform.position = new Vector3(playerPos.x, transform.position.y, playerPos.z - PlayerDirection);
        }
        else
        {
            switch (direction)
            {
                case Status.PlayerDirection.Front:
                    transform.position = new Vector3(playerPos.x, transform.position.y, playerPos.z - PlayerDirection);
                    break;
                case Status.PlayerDirection.Right:
                    transform.position = new Vector3(playerPos.x - PlayerDirection, transform.position.y, playerPos.z);
                    break;
                case Status.PlayerDirection.Back:
                    transform.position = new Vector3(playerPos.x, transform.position.y, playerPos.z + PlayerDirection);
                    break;
                case Status.PlayerDirection.Left:
                    transform.position = new Vector3(playerPos.x + PlayerDirection, transform.position.y, playerPos.z);
                    break;
            }
        }
    }
}
