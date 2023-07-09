using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// クナイの動きを管理するスクリプト
////////////////////////////////////

public class MoveAttack : MonoBehaviour
{
    //移動速度
  
    Vector3 velocity = new Vector3(0f, 0f, -80f);

    //コンポーネントを入れる変数
    Rigidbody rd;

    void Awake()
    {
        //コンポーネント取得
        rd = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //プレイヤーに向かって移動
        rd.velocity = this.velocity;
    }
}
