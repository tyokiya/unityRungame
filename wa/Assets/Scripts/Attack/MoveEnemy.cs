using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    //移動速度
    //[SerializeField] float MoveSpeed = 0.3f;
    [SerializeField] Vector3 velocity = new Vector3(0f, 0f, -5f);

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
