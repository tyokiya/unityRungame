using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Status;
using static UnityEditor.PlayerSettings;

////////////////////////////////////
// カメラのコントローラースクリプト
////////////////////////////////////

public class CameraController : MonoBehaviour
{
    //カメラとプレイヤーの一定距離
    float playerDistance = 3.5f;

    /// <summary>
    /// カメラの情報更新
    /// </summary>
    /// <param name="playerPos">現在のプレイヤーの座標</param>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    public void UpdateCamera(Vector3 playerPos, Status.PlayerDirection direction)
    {
        //プレイヤーの向いてる方向をもとに
        //カメラの向きを変える
        RotationCamera(direction);

        //プレイヤーの向いてる方向をもとに
        //常に一定の距離を保ちながらプレイヤーを追従
        MoveCamera(playerPos,direction);

    }

    /// <summary>
    /// カメラの向き回転処理
    /// </summary>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    void RotationCamera(Status.PlayerDirection direction)
    {
        switch (direction)
        {
            case PlayerDirection.front:
                //前を向かせる　
                transform.eulerAngles = new Vector3(20.0f,0, 0);
                break;
            case PlayerDirection.right:
                //右を向かせる　
                transform.eulerAngles = new Vector3(20.0f, 90.0f, 0);
                break;
            case PlayerDirection.back:
                //後を向かせる　
                transform.eulerAngles = new Vector3(20.0f, 180.0f, 0);
                break;
            case PlayerDirection.left:
                //左を向かせる　
                transform.eulerAngles = new Vector3(20.0f, 270.0f, 0);
                break;
        }
    }

    /// <summary>
    /// カメラの追従処理
    /// </summary>
    /// <param name="playerPos">現在のプレイヤーの座標</param>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    void MoveCamera(Vector3 playerPos, Status.PlayerDirection direction)
    {
        switch (direction)
        {
            case PlayerDirection.front:
                transform.position = new Vector3(playerPos.x, transform.position.y, playerPos.z - playerDistance);
                break;
            case PlayerDirection.right:
                transform.position = new Vector3(playerPos.x - playerDistance, transform.position.y, playerPos.z);
                break;
            case PlayerDirection.back:
                transform.position = new Vector3(playerPos.x, transform.position.y, playerPos.z + playerDistance);
                break;
            case PlayerDirection.left:
                transform.position = new Vector3(playerPos.x + playerDistance, transform.position.y, playerPos.z);
                break;
        }
    }
}
