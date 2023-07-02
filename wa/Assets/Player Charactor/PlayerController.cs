using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //アニメーターを入れる変数
    Animator animator;
    //リジッドボディを入れる変数
    Rigidbody rd;
    //ジャンプ力
    float jumpForce = 500.0f;

    void Start()
    {
        //コンポーネント取得
        this.animator = GetComponent<Animator>();
        this.rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプ処理
        if(Input.GetKeyDown(KeyCode.Space) && this.rd.velocity.y == 0)
        {
            //ジャンプアニメーションのトリガーに切り替える
            this.animator.SetTrigger("JumpTrigger");
            //y軸に力を加える
            this.rd.AddForce(transform.up * this.jumpForce);
        }
    }
}
