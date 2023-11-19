using UnityEngine;
using static Status;

/// <summary>
/// カメラのコントローラークラス
/// </summary>
public class CameraController : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] Camera Maincamera;
    [SerializeField] GroudCheck GroudCheck; 

    // 変更前のプレイヤーの向き
    PlayerDirection beforeDirection = Status.PlayerDirection.Front; 

    int addTurnCnt = 0; // 角度に加算した回数のカウンタ
    Vector3 TurnCameraCentorPos = Vector3.zero;    // 回転時のカメラの中心座標 

    const float TurnAngleSpeed  = 9.0f; // カメラの振り向き速度定数
    const float AngularVelocity = 0.6f; // カメラの回転時の移動速度定数
    const float PlayerDirection = 6.0f; // プレイヤーとカメラの距離定数
    const int   MaxTurnCnt      = 10;   // 振り向きの最大回数の定数
    const float RunCameraFOV    = 75;   // 走り中のカメラ画角
    const float UpFOV           = 0.2f; // 1フレ当たりの画角増加量

    /// <summary>
    /// カメラの情報更新
    /// </summary>
    /// <param name="playerPos">現在のプレイヤーの座標</param>
    /// <param name="currentDirection">現在のプレイヤーの向いてる方向</param>
    /// <param name="state">現在のプレイヤーの状態</param>
    public void UpdateCamera(Vector3 playerPos, PlayerDirection currentDirection, PlayerState state)
    {
        // 回転地面の座標取得
        TurnCameraCentorPos = GroudCheck.GetTurnGroundPos();

        // プレイヤーの向いてる方向に変更があったら
        // カメラの向きを変える(走り出して以降)
        if(state == PlayerState.Run && currentDirection != beforeDirection)
        {
            RotationCamera(currentDirection);
        }
        else
        {
            // プレイヤーの向いてる方向をもとに
            // 常に一定の距離を保ちながらプレイヤーを追従
            MoveCamera(playerPos, currentDirection, state);
        }
        
        // 走り出したらFOVの更新
        if(state != PlayerState.Walk)
        {
            UpdateFOV();
        }
    }

    void UpdateFOV()
    {
        if(Maincamera.fieldOfView <= RunCameraFOV)
        {
            Maincamera.fieldOfView += UpFOV;
        }
    }

    /// <summary>
    /// カメラの向き回転処理
    /// </summary>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    void RotationCamera(PlayerDirection direction)
    {
        // カウント増加
        addTurnCnt++;

        // プレイヤーの向いてる方向に合わせてカメラの回転処理
        switch (direction)
        {
            case Status.PlayerDirection.Front: // 前を向かせる　
                if (beforeDirection == Status.PlayerDirection.Left)
                {
                    transform.eulerAngles += new Vector3(0, TurnAngleSpeed, 0);
                    transform.position += new Vector3(-AngularVelocity, 0, -AngularVelocity);
                }
                else if (beforeDirection == Status.PlayerDirection.Right)
                {
                    transform.eulerAngles -= new Vector3(0, TurnAngleSpeed, 0);
                    transform.position += new Vector3(AngularVelocity, 0, -AngularVelocity);
                }
                break;
            case Status.PlayerDirection.Right: // 右を向かせる　
                if (beforeDirection == Status.PlayerDirection.Front)
                {
                    transform.eulerAngles += new Vector3(0, TurnAngleSpeed, 0);
                    transform.position += new Vector3(-AngularVelocity, 0, AngularVelocity);
                }
                else if(beforeDirection == Status.PlayerDirection.Back)
                {
                    transform.eulerAngles -= new Vector3(0, TurnAngleSpeed, 0);
                    transform.position += new Vector3(-AngularVelocity, 0, -AngularVelocity);
                }
                break;
            case Status.PlayerDirection.Back: // 後ろを向かせる
                if (beforeDirection == Status.PlayerDirection.Right)
                {
                    transform.eulerAngles += new Vector3(0, TurnAngleSpeed, 0);
                    transform.position += new Vector3(AngularVelocity, 0, AngularVelocity);
                }
                else if (beforeDirection == Status.PlayerDirection.Left)
                {
                    transform.eulerAngles -= new Vector3(0, TurnAngleSpeed, 0);
                    transform.position += new Vector3(-AngularVelocity, 0, AngularVelocity);
                }
                break;
            case Status.PlayerDirection.Left: // 左を向かせる　
                if (beforeDirection == Status.PlayerDirection.Back)
                {
                    transform.eulerAngles += new Vector3(0, TurnAngleSpeed, 0);
                    transform.position += new Vector3(AngularVelocity, 0, -AngularVelocity);
                }
                else if (beforeDirection == Status.PlayerDirection.Front)
                {
                    transform.eulerAngles -= new Vector3(0, TurnAngleSpeed, 0);
                    transform.position += new Vector3(AngularVelocity, 0, AngularVelocity);
                }
                break;
        }

        // カウントが30回になったら回転処理完了
        // プレイヤーの変更前の向きを更新
        if (addTurnCnt == MaxTurnCnt)
        {
            beforeDirection = direction; // 変更後の方向を保持          
            addTurnCnt = 0;              // カウント初期化
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
            // プレイヤーの方向に合わせて常に一定距離を開け追従
            switch (direction)
            {
                case Status.PlayerDirection.Front:
                    transform.position = new Vector3(TurnCameraCentorPos.x, transform.position.y, playerPos.z - PlayerDirection);
                    break;
                case Status.PlayerDirection.Right:
                    transform.position = new Vector3(playerPos.x - PlayerDirection, transform.position.y, TurnCameraCentorPos.z);
                    break;
                case Status.PlayerDirection.Back:
                    transform.position = new Vector3(TurnCameraCentorPos.x, transform.position.y, playerPos.z + PlayerDirection);
                    break;
                case Status.PlayerDirection.Left:
                    transform.position = new Vector3(playerPos.x + PlayerDirection, transform.position.y, TurnCameraCentorPos.z);
                    break;
            }
        }
    }
}
