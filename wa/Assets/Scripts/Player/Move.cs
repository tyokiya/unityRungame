using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using static Status;

////////////////////////////////////
// プレイヤーの動きを管理するスクリプト
////////////////////////////////////

public class Move : MonoBehaviour
{
    //親オブジェクト
    GameObject ParentObject;

    //リジッドボディを入れる変数
    Rigidbody rd;
    Transform pos;

    [SerializeField]
    //ジャンプ力
    private float jumpForce = 500.0f;

    //歩くスピード
    [SerializeField] float walkSpeed = 1f;
    //走るスピード
    [SerializeField] float runSpeed = 5f;
    //走ってる時のベロシティ
    Vector3 Velocity = new Vector3(0f, 0f, 0f);

    //テスト用スピード
    //float walkSpeed = 0.001f;
    //float runSpeed = 0.01f;


    //インスペクターから設定
    //プレイヤーマネージャーのスクリプト
    public PlayerManager manager;

    void Awake()
    {
        //親オブジェクトを取得
        ParentObject = GameObject.Find("Player");
        //コンポーネント取得
        this.rd = ParentObject.GetComponent<Rigidbody>();
        this.pos = ParentObject.GetComponent<Transform>();
    }

    /// <summary>
    /// プレイヤーを入力状態に応じて動かす
    /// </summary>
    /// <param name="flick">現在の入力状態</param>
    /// <param name="situation">現在のプレイヤーの状態</param>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    public void MovePlayerUpdate(ScreenInput.FlickDirection flick, Status.PlayerSituation situation, Status.PlayerDirection direction)
    {

        //向いてる方向と状態に合わせてvelosityの更新
        if (situation == PlayerSituation.walk)
        {
            this.Velocity = new Vector3(0f, 0f, this.walkSpeed);
        }
        else
        {
            switch (direction)
            {
                case PlayerDirection.front:
                    this.Velocity = new Vector3(0f, 0f, this.runSpeed);
                    break;
                case PlayerDirection.right:
                    this.Velocity = new Vector3(this.runSpeed, 0f, 0f);
                    break;
                case PlayerDirection.back:
                    this.Velocity = new Vector3(0f, 0f, this.runSpeed * -1);
                    break;
                case PlayerDirection.left:
                    this.Velocity = new Vector3(this.runSpeed * -1, 0f, 0f);
                    break;
            }
        }

        //移動処理
        if(situation == Status.PlayerSituation.run || situation == Status.PlayerSituation.walk)
        {
            rd.velocity = this.Velocity;
        }

        //ジャンプ処理
        if (flick == ScreenInput.FlickDirection.UP && situation == Status.PlayerSituation.run)
        {
            //ジャンプ
            PlayerJump();
        }

        //現在の向きに合わせてプレイヤーを回転
        RotationPlayer(direction);

  
    }

    /// <summary>
    /// プレイヤーのジャンプ処理
    /// </summary>
    void PlayerJump()
    {
        //y軸に力を加える
        this.rd.AddForce(transform.up * this.jumpForce);
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
                this.pos.eulerAngles = new Vector3(0, 0, 0);
                break;
            case PlayerDirection.right:
                //右を向かせる　
                this.pos.eulerAngles = new Vector3(0, 90.0f, 0);
                break;
            case PlayerDirection.back:
                //後を向かせる　
                this.pos.eulerAngles = new Vector3(0, 180.0f, 0);
                break;
            case PlayerDirection.left:
                //左を向かせる　
                this.pos.eulerAngles = new Vector3(0, 270.0f, 0);
                break;
        }
    }
}
