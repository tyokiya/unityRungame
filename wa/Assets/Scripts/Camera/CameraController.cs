using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Status;

////////////////////////////////////
// カメラのコントローラースクリプト
////////////////////////////////////

public class CameraController : MonoBehaviour
{
    //カメラの振り向き速度
    float turnAngleSpeed = 6.0f;
    float turnMoveSpeed = 0.2f;

    //プレイヤーとカメラの距離
    float playerDirection = 5.0f;

    //変更前のプレイヤーの向き
    PlayerDirection beforeDirection = PlayerDirection.front;

    //角度に加算した回数をカウントする変数
    int turnCnt = 0;
    //振り向きのマックス回数
    int maxTurnCnt = 15;

    /// <summary>
    /// カメラの情報更新
    /// </summary>
    /// <param name="playerPos">現在のプレイヤーの座標</param>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    /// <param name="situation">現在のプレイヤーの状態</param>
    public void UpdateCamera(Vector3 playerPos, PlayerDirection nowDirection, PlayerSituation situation)
    {
        //プレイヤーの向いてる方向に変更があったら
        //カメラの向きを変える(走り出して以降)
        if(situation == PlayerSituation.run && nowDirection != this.beforeDirection)
        {
            RotationCamera(nowDirection);
        }
        //プレイヤーの向いてる方向をもとに
        //常に一定の距離を保ちながらプレイヤーを追従
        MoveCamera(playerPos, nowDirection, situation);
    }

    /// <summary>
    /// カメラの向き回転処理
    /// </summary>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    void RotationCamera(PlayerDirection direction)
    {
        //カウント増加
        this.turnCnt++;

        switch (direction)
        {
            case PlayerDirection.front:
                //前を向かせる　
                if (this.beforeDirection == PlayerDirection.left)
                {
                    transform.eulerAngles += new Vector3(0, this.turnAngleSpeed, 0);
                    transform.position += new Vector3(-turnMoveSpeed, 0, -turnMoveSpeed);
                }
                else if (this.beforeDirection == PlayerDirection.right)
                {
                    transform.eulerAngles -= new Vector3(0, this.turnAngleSpeed, 0);
                    transform.position += new Vector3(turnMoveSpeed, 0, -turnMoveSpeed);
                }
                //カウントが30回になったら回転処理完了
                //プレイヤーの変更前の向きを更新
                if (this.turnCnt == this.maxTurnCnt)
                {
                    this.beforeDirection = PlayerDirection.front;
                    //カウント初期化
                    this.turnCnt = 0;
                }
                break;
            case PlayerDirection.right:
                //右を向かせる　
                if(this.beforeDirection == PlayerDirection.front)
                {
                    transform.eulerAngles += new Vector3(0, this.turnAngleSpeed, 0);
                    transform.position += new Vector3(-turnMoveSpeed, 0, turnMoveSpeed);
                }
                else if(this.beforeDirection == PlayerDirection.back)
                {
                    transform.eulerAngles -= new Vector3(0, this.turnAngleSpeed, 0);
                    transform.position += new Vector3(-turnMoveSpeed, 0, -turnMoveSpeed);
                }
                //カウントが30回になったら回転処理完了
                //プレイヤーの変更前の向きを更新
                if (this.turnCnt == this.maxTurnCnt)
                {
                    this.beforeDirection = PlayerDirection.right;
                    //カウント初期化
                    this.turnCnt = 0;
                }
                break;
            case PlayerDirection.back:
                //後を向かせる　
                if (this.beforeDirection == PlayerDirection.right)
                {
                    transform.eulerAngles += new Vector3(0, this.turnAngleSpeed, 0);
                    transform.position += new Vector3(turnMoveSpeed, 0, turnMoveSpeed);
                }
                else if (this.beforeDirection == PlayerDirection.left)
                {
                    transform.eulerAngles -= new Vector3(0, this.turnAngleSpeed, 0);
                    transform.position += new Vector3(-turnMoveSpeed, 0, turnMoveSpeed);
                }
                //カウントが30回になったら回転処理完了
                //プレイヤーの変更前の向きを更新
                if (this.turnCnt == this.maxTurnCnt)
                {
                    this.beforeDirection = PlayerDirection.back;
                    //カウント初期化
                    this.turnCnt = 0;
                }
                break;
            case PlayerDirection.left:
                //左を向かせる　
                if (this.beforeDirection == PlayerDirection.back)
                {
                    transform.eulerAngles += new Vector3(0, this.turnAngleSpeed, 0);
                    transform.position += new Vector3(turnMoveSpeed, 0, -turnMoveSpeed);
                }
                else if (this.beforeDirection == PlayerDirection.front)
                {
                    transform.eulerAngles -= new Vector3(0, this.turnAngleSpeed, 0);
                    transform.position += new Vector3(turnMoveSpeed, 0, turnMoveSpeed);
                }
                //カウントが30回になったら回転処理完了
                //プレイヤーの変更前の向きを更新
                if (this.turnCnt == this.maxTurnCnt)
                {
                    this.beforeDirection = PlayerDirection.left;
                    //カウント初期化
                    this.turnCnt = 0;
                }
                break;
        }
    }

    /// <summary>
    /// カメラの追従処理
    /// </summary>
    /// <param name="playerPos">現在のプレイヤーの座標</param>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    void MoveCamera(Vector3 playerPos, PlayerDirection direction, PlayerSituation situation)
    {
        if(situation == PlayerSituation.walk)
        {
            transform.position = new Vector3(playerPos.x, transform.position.y, playerPos.z - this.playerDirection);
        }
        else
        {
            switch (direction)
            {
                case PlayerDirection.front:
                    transform.position = new Vector3(playerPos.x, transform.position.y, playerPos.z - this.playerDirection);

                    break;
                case PlayerDirection.right:
                    transform.position = new Vector3(playerPos.x - this.playerDirection, transform.position.y, playerPos.z);
                    break;
                case PlayerDirection.back:
                    transform.position = new Vector3(playerPos.x, transform.position.y, playerPos.z + this.playerDirection);
                    break;
                case PlayerDirection.left:
                    transform.position = new Vector3(playerPos.x + this.playerDirection, transform.position.y, playerPos.z);
                    break;
            }
        }
    }
}
