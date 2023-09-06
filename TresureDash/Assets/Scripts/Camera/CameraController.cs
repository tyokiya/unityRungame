﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Status;

////////////////////////////////////
// カメラのコントローラースクリプト
////////////////////////////////////

public class CameraController : MonoBehaviour
{
    [Tooltip("カメラの振り向き速度定数")]
    const float turnAngleSpeed_const = 9.0f;
    [Tooltip("カメラの回転時の移動速度定数")]
    const float angularVelocity_const = 0.6f;

    [Tooltip("プレイヤーとカメラの距離定数")]
    const float playerDirection_const = 5.0f;

    [Tooltip("変更前のプレイヤーの向き")]
    PlayerDirection beforeDirection = PlayerDirection.front;

    [Tooltip("角度に加算した回数のカウンタ")]
    int turnCnt = 0;

    [Tooltip("振り向きの最大回数の定数")]
    const int maxTurnCnt_const = 10;

    /// <summary>
    /// カメラの情報更新
    /// </summary>
    /// <param name="playerPos">現在のプレイヤーの座標</param>
    /// <param name="currentDirection">現在のプレイヤーの向いてる方向</param>
    /// <param name="state">現在のプレイヤーの状態</param>
    public void UpdateCamera(Vector3 playerPos, PlayerDirection currentDirection, PlayerState state)
    {
        //プレイヤーの向いてる方向に変更があったら
        //カメラの向きを変える(走り出して以降)
        if(state == PlayerState.run && currentDirection != this.beforeDirection)
        {
            RotationCamera(currentDirection);
        }
        else
        {
            //プレイヤーの向いてる方向をもとに
            //常に一定の距離を保ちながらプレイヤーを追従
            MoveCamera(playerPos, currentDirection, state);
        }        
    }

    /// <summary>
    /// カメラの向き回転処理
    /// </summary>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    void RotationCamera(PlayerDirection direction)
    {
        //カウント増加
        this.turnCnt++;

        //プレイヤーの向いてる方向に合わせてカメラの回転処理
        switch (direction)
        {
            case PlayerDirection.front:
                //前を向かせる　
                if (this.beforeDirection == PlayerDirection.left)
                {
                    transform.eulerAngles += new Vector3(0, turnAngleSpeed_const, 0);
                    transform.position += new Vector3(-angularVelocity_const, 0, -angularVelocity_const);
                }
                else if (this.beforeDirection == PlayerDirection.right)
                {
                    transform.eulerAngles -= new Vector3(0, turnAngleSpeed_const, 0);
                    transform.position += new Vector3(angularVelocity_const, 0, -angularVelocity_const);
                }
                break;
            case PlayerDirection.right:
                //右を向かせる　
                if(this.beforeDirection == PlayerDirection.front)
                {
                    transform.eulerAngles += new Vector3(0, turnAngleSpeed_const, 0);
                    transform.position += new Vector3(-angularVelocity_const, 0, angularVelocity_const);
                }
                else if(this.beforeDirection == PlayerDirection.back)
                {
                    transform.eulerAngles -= new Vector3(0, turnAngleSpeed_const, 0);
                    transform.position += new Vector3(-angularVelocity_const, 0, -angularVelocity_const);
                }
                break;
            case PlayerDirection.back:
                //後を向かせる　
                if (this.beforeDirection == PlayerDirection.right)
                {
                    transform.eulerAngles += new Vector3(0, turnAngleSpeed_const, 0);
                    transform.position += new Vector3(angularVelocity_const, 0, angularVelocity_const);
                }
                else if (this.beforeDirection == PlayerDirection.left)
                {
                    transform.eulerAngles -= new Vector3(0, turnAngleSpeed_const, 0);
                    transform.position += new Vector3(-angularVelocity_const, 0, angularVelocity_const);
                }
                break;
            case PlayerDirection.left:
                //左を向かせる　
                if (this.beforeDirection == PlayerDirection.back)
                {
                    transform.eulerAngles += new Vector3(0, turnAngleSpeed_const, 0);
                    transform.position += new Vector3(angularVelocity_const, 0, -angularVelocity_const);
                }
                else if (this.beforeDirection == PlayerDirection.front)
                {
                    transform.eulerAngles -= new Vector3(0, turnAngleSpeed_const, 0);
                    transform.position += new Vector3(angularVelocity_const, 0, angularVelocity_const);
                }
                break;
        }
        //カウントが30回になったら回転処理完了
        //プレイヤーの変更前の向きを更新
        if (this.turnCnt == maxTurnCnt_const)
        {
            this.beforeDirection = direction;
            //カウント初期化
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
        if(state == PlayerState.walk)
        {
            transform.position = new Vector3(playerPos.x, transform.position.y, playerPos.z - playerDirection_const);
        }
        else
        {
            switch (direction)
            {
                case PlayerDirection.front:
                    transform.position = new Vector3(playerPos.x,                         transform.position.y, playerPos.z - playerDirection_const);
                    break;
                case PlayerDirection.right:
                    transform.position = new Vector3(playerPos.x - playerDirection_const, transform.position.y, playerPos.z);
                    break;
                case PlayerDirection.back:
                    transform.position = new Vector3(playerPos.x,                         transform.position.y, playerPos.z + playerDirection_const);
                    break;
                case PlayerDirection.left:
                    transform.position = new Vector3(playerPos.x + playerDirection_const, transform.position.y, playerPos.z);
                    break;
            }
        }
    }
}
