using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// 攻撃を管理するマネージャースクリプト
////////////////////////////////////

public class AttackManager : MonoBehaviour
{
    //インスペクターから設定
    //攻撃生成するスクリプト
    public AttackGenerator generator;

    //プレイヤーオブジェクトを入れる変数
    GameObject player;

    //攻撃の生成スパンの管理変数
    [SerializeField] float knifeSpan = 3.0f;
    [SerializeField] float makibishiSpan = 4.5f;

    //難易度アップのスパン
    [SerializeField] float levelUpSpan = 15.0f;
    //現在のゲーム難易度
    int nowGameLevel = 1;

    //タイマー
    float knifeDelta = 0;
    float makibishiDelta = 0;
    float gameDelta = 0;
    
    void Awake()
    {
        //プレイヤーオブジェクト代入
        this.player = GameObject.Find("Player");
    }


    void Update()
    {
        //スパンの間隔に応じて攻撃の生成の指示
        if (this.knifeDelta > this.knifeSpan)
        {
            //ナイフ攻撃生成
            generator.CreateKnife(this.player.transform.position);
            //デルタ初期化
            this.knifeDelta = 0;
        }
        if(this.makibishiDelta > this.makibishiSpan)
        {
            //まきびし生成
            generator.CreateMakibisi(this.player.transform.position);
            //デルタ初期化
            this.makibishiDelta = 0;
        }

        //levelUpSpanがきたら生成スパンと生成数を上げる
        if(this.gameDelta > this.levelUpSpan && this.nowGameLevel == 1)
        {
            //レベルアップ
            this.nowGameLevel = 2;
            //ナイフの生成数アップの指示
            generator.SetKnifeNum(2);
            //攻撃の生成スパンを縮める
            ChangeSpan(2.0f, 3.0f);
            
        }


        //デルタ増加
        this.knifeDelta += Time.deltaTime;
        this.makibishiDelta += Time.deltaTime;
        if(this.nowGameLevel == 1)
        {
            this.gameDelta += Time.deltaTime;
        }
    }

    /// <summary>
    /// プレイヤーの座標を攻撃に返す
    /// </summary>
    /// <returns>プレイヤー座標</returns>
    public Vector3 GetPlayerPos()
    {
        return player.transform.position;
    }

    /// <summary>
    /// 攻撃の生成スパン変更
    /// </summary>
    /// <param name="changeKnifeSpan">変更するナイフのスパン</param>
    /// <param name="changeMakibishiSpan">変更するまきびしのスパン</param>
    void ChangeSpan(float changeKnifeSpan, float changeMakibishiSpan)
    {
        this.knifeSpan = changeKnifeSpan;
        this.makibishiSpan = changeMakibishiSpan;
    }
}
