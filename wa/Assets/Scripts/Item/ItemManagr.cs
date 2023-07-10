using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagr : MonoBehaviour
{
    //インスペクターから設定
    //攻撃生成するスクリプト
    public ItemGenerator generator;

    //プレイヤーオブジェクトを入れる変数
    GameObject player;

    //攻撃の生成スパンの管理変数
    [SerializeField] float itemSpan = 10.0f;

    //タイマー
    float itemDelta = 0;

    void Awake()
    {
        //プレイヤーオブジェクト代入
        this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //スパンの間隔に応じてアイテムの生成の指示
        if(this.itemDelta > this.itemSpan)
        {
            this.generator.CreateItem(this.player.transform.position);
            //デルタ初期化
            this.itemDelta = 0;
        }

        //デルタ増加
        this.itemDelta += Time.deltaTime;
    }
}
