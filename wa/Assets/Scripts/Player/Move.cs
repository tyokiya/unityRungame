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
    [SerializeField] Vector3 walkVelocity = new Vector3 (0f, 0f, 1f);
    //走るスピード
    [SerializeField] Vector3 runVelocity = new Vector3(0f, 0f, 2f);
    //float runSpeed = 0.2f;
    //テスト用
    float runSpeed = 0.001f;


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
        //歩き状態のときはあるき処理のみ
        if(situation == Status.PlayerSituation.walk)
        {
            PlayerWalk();
        }
        else     //走り状態のときはフリックを受け取りそれに合わせた処理を行う
        {
            //ジャンプ処理
            if (flick == ScreenInput.FlickDirection.UP && situation == Status.PlayerSituation.run)
            {
                //ジャンプ
                PlayerJump();
            }
            //走り処理
            PlayerRun(direction);
            //現在の向きに合わせてプレイヤーを回転
            RotationPlayer(direction);
        }
        
    }

    /// <summary>
    /// プレイヤーのジャンプ処理
    /// </summary>
    void PlayerJump()
    {
        //y軸に力を加える
        this.rd.AddForce(transform.up * this.jumpForce);
        //仮実装
        transform.Translate(0, 0, 0.2f);
        //z軸の移動を加える
        //rd.velocity = this.runVelocity;
    }

    /// <summary>
    /// プレイヤーの走り移動
    /// </summary>
    /// <param name="direction">プレイヤーの方向</param>
    void PlayerRun(Status.PlayerDirection direction)
    {
        //rd.velocity = this.runVelocity;
        //プレイヤーの方向に合わせた移動処理
        switch (direction)
        {
            case PlayerDirection.front:
                pos.transform.Translate(0, 0, runSpeed);
                break;
            case PlayerDirection.right:
                pos.transform.Translate(runSpeed, 0, 0);
                break;
            case PlayerDirection.back:
                pos.transform.Translate(0, 0, -runSpeed);
                break;
            case PlayerDirection.left:
                pos.transform.Translate(-runSpeed, 0, 0);
                break;
        }

    }

    /// <summary>
    /// プレイヤーの歩き移動
    /// </summary>
    void PlayerWalk()
    {
        //z軸の移動を加える
        //rd.velocity = this.walkVelocity;

        //pos.transform.Translate(0, 0, 0.1f);
        //調整用
        pos.transform.Translate(0, 0, 0.001f);
    }

    /// <summary>
    /// プレイヤーの向きを回転ん
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
