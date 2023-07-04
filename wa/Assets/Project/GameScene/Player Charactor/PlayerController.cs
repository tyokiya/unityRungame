using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// プレイヤーのコントローラースクリプト
////////////////////////////////////

public class PlayerController : MonoBehaviour
{
    //アニメーターを入れる変数
    Animator animator;
    //リジッドボディを入れる変数
    Rigidbody rd;
    //入力状態を入れる変数
    GameObject inputDetector;

    //ジャンプ力
    [SerializeField]
    private float jumpForce = 500.0f;
    //移動スピード
    [SerializeField] 
    private float walkSpeed = 0.1f;
    private float runSpeed = 0.2f;
    //横移動距離
    private float lateralDistance = 0.8f;

    //タイマー
    float delta = 0;
    float startTime = 3.0f;
    //移動可能タイミングのスパン
    float lateralMoveSpan = 0.1f;

    //走っているかのフラグ
    bool runFlg = false;
   

    void Start()
    {
        //フレームレート固定
        Application.targetFrameRate = 30;
        //コンポーネント取得
        this.animator = GetComponent<Animator>();
        this.rd = GetComponent<Rigidbody>();
        //オブジェクトを入れる

    }

  
    void Update()
    {
        //開始から3秒後プレイヤーが走り始める
        if(this.delta > this.startTime && runFlg == false)
        {
            //runフラグをたてる
            this.runFlg = true;
            //runアニメーションのトリガーに切り替える
            this.animator.SetTrigger("RunTrigger");
        }

        //InputDetectorから入力状態を受け取る
        GameObject inputDetector = GameObject.Find("InputDetector");
        //入力状態に応じて移動
        switch (inputDetector.GetComponent<ScreenInput>().GetNowFlick())
        {
            case ScreenInput.FlickDirection.UP:         //ジャンプ処理
                PlayerJump();
                break;
            case ScreenInput.FlickDirection.RIGHT:      //右移動処理
                //連続で処理しないようスパンを設ける
                if(this.delta > this.lateralMoveSpan && this.runFlg == true)
                {
                    PlayerLateralMoveMent(true);
                }
                else //左右移動ができない場合は前へ進む
                {
                    PlayerMove(this.runFlg);
                }
                
                break;
            case ScreenInput.FlickDirection.LEFT:       //左移動処理
                //連続で処理しないようスパンを設ける
                if (this.delta > this.lateralMoveSpan && this.runFlg == true)
                {
                    PlayerLateralMoveMent(false);
                }
                else //左右移動ができない場合は前へ進む
                {
                    PlayerMove(this.runFlg);
                }
                break;
                default:
                PlayerMove(this.runFlg);                //プレイヤーの前移動(フラグの状態で速度を変える)
                break;
        }

        //カウントの増加
        this.delta += Time.deltaTime;
    }

    /// <summary>
    /// プレイヤーのジャンプ処理
    /// </summary>
    void PlayerJump()
    {
        if (this.rd.velocity.y == 0 && this.runFlg == true)
        {
            //ジャンプアニメーションのトリガーに切り替える
            this.animator.SetTrigger("JumpTrigger");
            //y軸に力を加える
            this.rd.AddForce(transform.up * this.jumpForce);
        }
    }
    
    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    /// <param name="flg">プレイヤーが走っいるかのフラグ</param>
    void PlayerMove(bool flg)
    {
        if (flg == false)
        {
            //歩き速度
            transform.Translate(0, 0, this.walkSpeed);
        }
        else
        {
            //走り速度
            transform.Translate(0, 0, this.runSpeed);
        }
    }

    /// <summary>
    /// プレイヤーの横移動
    /// </summary>
    /// <param name="rightFlg">右移動のフラグ(falseのときは左に動く)</param>
    void PlayerLateralMoveMent(bool rightFlg)
    {
        if (rightFlg == true && transform.position.x < 0.8)    //右移動
        {
            transform.Translate(this.lateralDistance, 0, this.runSpeed);
        }
        else if (rightFlg == false && transform.position.x > -0.8)//左移動 
        {
            transform.Translate(this.lateralDistance * -1, 0, this.runSpeed);
        }

        //delta初期化
        this.delta = 0;
    }
}
