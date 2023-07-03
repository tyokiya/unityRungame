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

    //ジャンプ力
    float jumpForce = 500.0f;
    //移動スピード
    float walkSpeed = 0.1f;
    float runSpeed = 0.2f;

    //タイマー
    float delta = 0;
    float startTime = 3.0f;

    //走っているかのフラグ
    bool runFlg = false;
    //スワイプ座標
    Vector3 swipStartPos;
    //スワイプの距離を入れる変数
    float swipLengthX, swipLengthY;

    void Start()
    {
        //フレームレート固定
        Application.targetFrameRate = 30;
        //コンポーネント取得
        this.animator = GetComponent<Animator>();
        this.rd = GetComponent<Rigidbody>();
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
        else
        {
            //カウントの増加
            this.delta += Time.deltaTime;
        }

        //スワイプの長さを求める
        if(Input.GetMouseButtonDown(0))
        {
            //クリック座標取得
            this.swipStartPos = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            //クリックを離した座標
            Vector3 endPos = Input.mousePosition;
            //スワイプ距離を計算
            this.swipLengthX = endPos.x - this.swipStartPos.x;
            this.swipLengthY = endPos.y - this.swipStartPos.y;
        }

        //ジャンプ処理
        if(this.swipLengthY > 100 && this.rd.velocity.y == 0 && this.runFlg == true)
        {
            //ジャンプアニメーションのトリガーに切り替える
            this.animator.SetTrigger("JumpTrigger");
            //y軸に力を加える
            this.rd.AddForce(transform.up * this.jumpForce);
            //レングス初期化
            this.swipLengthY = 0;
        }

        //左右移動処理
        

        //フラグで移動速度を変える
        if(this.runFlg == false)
        {
            //歩き速度
            transform.Translate(0,0,this.walkSpeed);
        }
        else
        {
            //走り速度
            transform.Translate(0,0,this.runSpeed);
        }
    }
}
