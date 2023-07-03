using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //プレイヤーオブジェクトを入れる変数
    GameObject player;
    void Start()
    {
        //代入
        this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの座標を取得
        Vector3 playerPos = this.player.transform.position;

        //常に一定の距離を保ちながらプレイヤーを追従
        transform.position = new Vector3(transform.position.x, transform.position.y, playerPos.z - 3.5f);
    }
}
