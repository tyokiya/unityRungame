using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

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
    //横移動スピード
    [SerializeField] Vector3 rightVelocity = new Vector3(0.1f, 0f, 1.5f);
    [SerializeField]Vector3 leftVelocity = new Vector3(-0.1f, 0f, 1.5f);

    //タイマー
    float delta = 0;
    //移動可能タイミングのスパン
    float lateralMoveSpan = 0.1f;

    void Awake()
    {
        //親オブジェクトを取得
        ParentObject = GameObject.Find("Player");
        //コンポーネント取得
        this.rd = ParentObject.GetComponent<Rigidbody>();
        this.pos = ParentObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //delta増加
        this.delta += Time.deltaTime;
    }
    /// <summary>
    /// プレイヤーを入力状態に応じて動かす
    /// </summary>
    /// <param name="nowFlick">現在の入力状態</param>
    public void MovePlayerUpdate(ScreenInput.FlickDirection flick, Status.situation situation)
    {
        //歩き状態のときはあるき処理のみ
        if(situation == Status.situation.walk)
        {
            PlayerWalk();
        }
        else     //走り状態のときはフリックを受け取りそれに合わせた処理を行う
        {
            //フリックに応じて処理
            switch (flick)
            {
                case ScreenInput.FlickDirection.UP:             //ジャンプ処理
                    if (situation == Status.situation.run)
                    {
                        //ジャンプ
                        PlayerJump();
                    }
                    else//ジャンプできな場合前へ進む
                    {
                        PlayerRun();
                    }
                    break;
                case ScreenInput.FlickDirection.RIGHT:          //右移動処理
                                                                //連続で処理しないようスパンを設ける
                    if (this.delta > this.lateralMoveSpan && situation == Status.situation.run)
                    {
                        PlayerLateralMoveMent(true);
                    }
                    else         //横移動できないときは走り処理の実行
                    {
                        PlayerRun();
                    }
                    break;
                case ScreenInput.FlickDirection.LEFT:           //左移動処理
                                                                //連続で処理しないようスパンを設ける
                    if (this.delta > this.lateralMoveSpan && situation == Status.situation.run)
                    {
                        PlayerLateralMoveMent(false);
                    }
                    else         //横移動できないときは走り処理の実行
                    {
                        PlayerRun();
                    }
                    break;
                default:
                    //走り処理
                    PlayerRun();
                    break;
            }
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
    void PlayerRun()
    {
        //z軸の移動を加える
        //rd.velocity = this.runVelocity;

        pos.transform.Translate(0, 0, 0.2f);
    }

    /// <summary>
    /// プレイヤーの歩き移動
    /// </summary>
    void PlayerWalk()
    {
        //z軸の移動を加える
        //rd.velocity = this.walkVelocity;

        pos.transform.Translate(0, 0, 0.1f);
    }

    /// <summary>
    /// プレイヤーの横移動
    /// </summary>
    /// <param name="rightFlg">右移動のフラグ(falseのときは左に動く)</param>
    void PlayerLateralMoveMent(bool rightFlg)
    {
        if (rightFlg == true && this.pos.position.x < 0.8)    //右移動
        {
            //rd.velocity = rightVelocity;
            //仮実装
            this.pos.Translate(0.8f, 0, 0.2f);
        }
        else if (rightFlg == false && this.pos.position.x > -0.8)//左移動 
        {
            //rd.velocity = leftVelocity;
            //仮実装
            this.pos.Translate(0.8f * -1, 0, 0.2f);
        }

        //delta初期化
        this.delta = 0;
    }
}
