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

    [Tooltip("プレイヤーが正面を向いている時の角度")]
    Vector3 frontAngle = Vector3.zero;
    [Tooltip("プレイヤーが右を向いている時の角度")]
    Vector3 rightAngle = new Vector3(0, 90, 0);
    [Tooltip("プレイヤーが後ろを向いている時の角度")]
    Vector3 backAngle = new Vector3(0,180,0);
    [Tooltip("プレイヤーが左を向いている時の角度")]
    Vector3 leftAngle = new Vector3(0, 270, 0);

    //現在のジャンプ力
    float now_jumpForce = 0;

    //ジャンプ力重力の定数
    const float jumpForce_const = 0.21f;
    const float down_jumpForce_const = 0.004f;
    
    //移動スピードの定数
    const float walkSpeed_const = 0.01f;
    const float runSpeed_const = 0.3f;
    const float sideMoveSpeed_const = 0.08f;

    void Update()
    {
        //毎フレームジャンプ力の減少(0以下になることはない)
        if(this.now_jumpForce > 0)
        {
            this.now_jumpForce -= down_jumpForce_const;
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
    /// <param name="tili_direction">前フレームとのスマホの傾きの差</param>
    /// <param name="turnGroundFlg">回転可能な地面の上に立っているかのフラグ</param>
    /// <param name="ply_jumpSound_delegate">ジャンプ音再生のデリゲート</param>
    public void MovePlayerUpdate(ScreenInput.FlickDirection flick, Status.PlayerSituation situation, Status.PlayerDirection direction, GyroInput.TiltDirection tili_direction,
                                 bool turnGroundFlg, SoundController.ply_playerSound_delegate ply_jumpSound_delegate)
    {
        //ジャンプの入力でジャンプ力を入れる
        if (flick == ScreenInput.FlickDirection.UP && situation == Status.PlayerSituation.run)
        {
            //現在のジャンプ力に力を代入
            this.now_jumpForce = jumpForce_const;
            //ジャンプ音再生
            ply_jumpSound_delegate();
        }

        //回転可能な地面の上か歩き常態である時場合ジャイロを考慮しない
        if (turnGroundFlg == true || situation == PlayerSituation.walk 
            || tili_direction == GyroInput.TiltDirection.FRONT)
        {
            //回転可能な地面の上での移動処理
            //歩きモーション中の移動処理
            MovePlayer(situation, direction);
        }
        else
        {
            //横移動を含めた移動処理
            MoveSide(direction, tili_direction);
        }
        
        //現在の向きに合わせてプレイヤーを回転
        RotationPlayer(direction);
    }

    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>
    /// <param name="situation">現在のプレイヤーの状態</param>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    void MovePlayer(Status.PlayerSituation situation, Status.PlayerDirection direction)
    {
        if (situation == PlayerSituation.walk)
        {
            this.rd.MovePosition(new Vector3(parent_transform.position.x, parent_transform.position.y, parent_transform.position.z + walkSpeed_const));
        }
        else
        {
            switch (direction)
            {
                case PlayerDirection.front:
                    this.rd.MovePosition(new Vector3(parent_transform.position.x, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z + runSpeed_const));
                    break;
                case PlayerDirection.right:
                    this.rd.MovePosition(new Vector3(parent_transform.position.x + runSpeed_const, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z));
                    break;
                case PlayerDirection.back:
                    this.rd.MovePosition(new Vector3(parent_transform.position.x, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z - runSpeed_const));
                    break;
                case PlayerDirection.left:
                    this.rd.MovePosition(new Vector3(parent_transform.position.x - runSpeed_const, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z));
                    break;
            }
        }
    }

    /// <summary>
    /// スマホの傾きによる横移動処理
    /// </summary>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    /// <param name="tili_direction">スマホの傾き方向</param>
    void MoveSide(PlayerDirection direction, GyroInput.TiltDirection tili_direction)
    {
        //傾きと向いてる向きから移動処理をだす
        switch (direction)
        {
            case PlayerDirection.front:
                //傾きに合わせた横移動
                if (tili_direction == GyroInput.TiltDirection.RIGHT)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x + sideMoveSpeed_const, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z + runSpeed_const));
                }
                else if(tili_direction == GyroInput.TiltDirection.LEFT)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x - sideMoveSpeed_const, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z + runSpeed_const));
                }
                break;
            case PlayerDirection.right:
                if (tili_direction == GyroInput.TiltDirection.RIGHT)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x + runSpeed_const, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z - sideMoveSpeed_const));
                }
                else if(tili_direction == GyroInput.TiltDirection.LEFT)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x + runSpeed_const, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z + sideMoveSpeed_const));
                }
                break;
            case PlayerDirection.back:
                if (tili_direction == GyroInput.TiltDirection.RIGHT)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x - sideMoveSpeed_const, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z - runSpeed_const));
                }
                else if (tili_direction == GyroInput.TiltDirection.LEFT)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x + sideMoveSpeed_const, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z - runSpeed_const));
                }
                break;
            case PlayerDirection.left:
                if (tili_direction == GyroInput.TiltDirection.RIGHT)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x - runSpeed_const, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z + sideMoveSpeed_const));
                }
                else if (tili_direction == GyroInput.TiltDirection.LEFT)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x - runSpeed_const, parent_transform.position.y + this.now_jumpForce, parent_transform.position.z - sideMoveSpeed_const));
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
                this.parent_transform.eulerAngles = this.frontAngle;
                break;
            case PlayerDirection.right:
                //右を向かせる　
                this.parent_transform.eulerAngles = this.rightAngle;
                break;
            case PlayerDirection.back:
                //後を向かせる　
                this.parent_transform.eulerAngles = this.backAngle;
                break;
            case PlayerDirection.left:
                //左を向かせる　
                this.parent_transform.eulerAngles = this.leftAngle;
                break;
        }
    }

}
