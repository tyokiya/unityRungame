using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UIElements;
using static Status;

////////////////////////////////////
// プレイヤーの動きを管理するスクリプト
////////////////////////////////////

public class Move : MonoBehaviour
{
    //インスペクターから設定
    //プレイヤーマネージャーのオブジェクト
    [SerializeField] PlayerManager playerManager_object;
    //リジッドボディを入れる変数
    [SerializeField] Rigidbody rd;
    //親オブジェクトのトランスフォームを入れる変数
    [SerializeField] Transform parent_transform;

    //ジャンプ力
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] float down_jumpForce = 0.08f;
    float now_jumpForce = 0;

    //歩くスピード
    [SerializeField] float walkSpeed = 1f;
    //走るスピード
    [SerializeField] float runSpeed = 5f;
    //横移動のスピード
    [SerializeField] float sideMoveSpeed = 0.01f;

    void Update()
    {
        //毎フレームジャンプ力の減少(0以下になることはない)
        if(now_jumpForce > 0)
        {
            this.now_jumpForce -= this.down_jumpForce;
            if(this.now_jumpForce < 0)
            {
                this.now_jumpForce = 0;
            }
        }
    }

    /// <summary>
    /// プレイヤーを入力状態に応じて動かす
    /// </summary>
    /// <param name="flick">現在の入力状態</param>
    /// <param name="situation">現在のプレイヤーの状態</param>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    /// <param name="difference_tilt">前フレームとのスマホの傾きの差</param>
    /// <param name="turnGroundFlg">回転可能な地面の上に立っているかのフラグ</param>
    public void MovePlayerUpdate(ScreenInput.FlickDirection flick, Status.PlayerSituation situation, Status.PlayerDirection direction,float difference_tilt,bool turnGroundFlg)
    {
        //ジャンプの入力でジャンプ力を入れる
        if (flick == ScreenInput.FlickDirection.UP && situation == Status.PlayerSituation.run)
        {
            //現在のジャンプ力に力を代入
            this.now_jumpForce = this.jumpForce;
        }

        if (turnGroundFlg == true || situation == PlayerSituation.walk)
        {
            //回転可能な地面の上での移動処理
            //歩きモーション中の移動処理
            MovePlayer(situation, direction, difference_tilt);
        }
        else
        {
            //横移動を含めた移動処理
            MoveSide(direction, difference_tilt);
        }
        
        //現在の向きに合わせてプレイヤーを回転
        RotationPlayer(direction);
    }

    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>
    /// <param name="situation">現在のプレイヤーの状態</param>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    /// <param name="difference_tilt">スマホの傾き</param>
    void MovePlayer(Status.PlayerSituation situation, Status.PlayerDirection direction, float difference_tilt)
    {
        if (situation == PlayerSituation.walk)
        {
            this.rd.MovePosition(new Vector3(parent_transform.position.x, parent_transform.position.y, parent_transform.position.z + walkSpeed));
        }
        else
        {
            switch (direction)
            {
                case PlayerDirection.front:
                    this.rd.MovePosition(new Vector3(parent_transform.position.x, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z + runSpeed));
                    break;
                case PlayerDirection.right:
                    this.rd.MovePosition(new Vector3(parent_transform.position.x + runSpeed, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z));
                    break;
                case PlayerDirection.back:
                    this.rd.MovePosition(new Vector3(parent_transform.position.x, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z - runSpeed));
                    break;
                case PlayerDirection.left:
                    this.rd.MovePosition(new Vector3(parent_transform.position.x - runSpeed, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z));
                    break;
            }
        }
    }

    /// <summary>
    /// スマホの傾きによる横移動処理
    /// </summary>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    /// <param name="difference_tilt">スマホの傾き</param>
    void MoveSide(PlayerDirection direction, float difference_tilt)
    {
        //傾きと向いてる向きから移動処理をだす
        switch (direction)
        {
            case PlayerDirection.front:
                if (difference_tilt > 0 && difference_tilt < 100)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x + this.sideMoveSpeed, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z + runSpeed));
                }
                else
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x - this.sideMoveSpeed, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z + runSpeed));
                }
                break;
            case PlayerDirection.right:
                if (difference_tilt > 0 && difference_tilt < 100)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x + runSpeed, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z - this.sideMoveSpeed));
                }
                else
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x + runSpeed, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z + this.sideMoveSpeed));
                }
                break;
            case PlayerDirection.back:
                if (difference_tilt > 0 && difference_tilt < 100)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x - this.sideMoveSpeed, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z - runSpeed));
                }
                else
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x + this.sideMoveSpeed, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z - runSpeed));
                }
                break;
            case PlayerDirection.left:
                if (difference_tilt > 0 && difference_tilt < 100)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x - runSpeed, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z + this.sideMoveSpeed));
                }
                else
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x - runSpeed, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z - this.sideMoveSpeed));
                }
                break;
        }
    }

    /// <summary>
    /// プレイヤーの向きを回転
    /// </summary>
    /// <param name="direction">プレイヤーの向いてる方向</param>
    void RotationPlayer(Status.PlayerDirection direction)
    {
        //ステータスの向いてる方向に応じて回転
        switch(direction)
        {
            case PlayerDirection.front:
                //前を向かせる　
                this.parent_transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case PlayerDirection.right:
                //右を向かせる　
                this.parent_transform.eulerAngles = new Vector3(0, 90.0f, 0);
                break;
            case PlayerDirection.back:
                //後を向かせる　
                this.parent_transform.eulerAngles = new Vector3(0, 180.0f, 0);
                break;
            case PlayerDirection.left:
                //左を向かせる　
                this.parent_transform.eulerAngles = new Vector3(0, 270.0f, 0);
                break;
        }
    }

}
