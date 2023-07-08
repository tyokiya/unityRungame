using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    //インスペクターから設定
    //攻撃生成するスクリプト
    public AttackGenerator generator;

    //プレイヤーオブジェクトを入れる変数
    GameObject player;

    //攻撃の生成スパンの管理変数
    [SerializeField] float initialKnifeSpan = 3.0f;
    [SerializeField] float initialMakibishiSpan = 4.5f;

    //タイマー
    float knifeDelta = 0;
    float makibishiDelta = 0;
    
    void Awake()
    {
        //代入
        this.player = GameObject.Find("Player");
    }


    void Update()
    {
        //スパンの間隔に応じて攻撃の生成の指示
        if (this.knifeDelta > this.initialKnifeSpan)
        {
            //ナイフ攻撃生成
            generator.CreateKnife(this.player.transform.position);
            //デルタ初期化
            this.knifeDelta = 0;
        }
        if(this.makibishiDelta > this.initialMakibishiSpan)
        {
            //まきびし生成
            generator.CreateMakibisi(this.player.transform.position);
            //デルタ初期化
            this.makibishiDelta = 0;
        }
        //デルタ増加
        this.knifeDelta += Time.deltaTime;
        this.makibishiDelta += Time.deltaTime;
    }
}
