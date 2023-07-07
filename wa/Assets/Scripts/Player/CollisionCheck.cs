using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// プレイヤーの被弾を管理するスクリプト
////////////////////////////////////

public class CollisionCheck : MonoBehaviour
{
    //攻撃のタグ名
    string attackTag = "Attack";
    //アイテムのタグ名
    string ItemTag = "Item";

    //ダメージタイマー
    float damageDelta = 0;
    //アイテムタイマー
    float itemDelta = 0;
    //次のダメージを受けるまでのスパン
    float damageSpan = 0.5f;
    //次のアイテムを獲得するまでのスパン
    float itemGetSpan = 0.5f;

    //インスペクターから設定
    //プレイヤーマネージャーのスクリプト
    public PlayerManager manager;

    private void Update()
    {
        //タイマーの増加
        this.damageDelta += Time.deltaTime;
        this.itemDelta += Time.deltaTime;

        //オーバーフローさせない処理
        if(this.itemDelta > float.MaxValue)
        {
            this.itemDelta = 0;
        }
        if(this.damageDelta > float.MaxValue)
        {
            this.damageDelta = 0;
        }
    }

    /// <summary>
    /// 衝突を感知しマネージャーに知らせる
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //衝突したものが攻撃なのかを調べる
        //連続で衝突を呼び出さないようスパンを設ける
        if (other.tag == this.attackTag && this.damageDelta > this.damageSpan)
        {
            //Debug.Log("攻撃と衝突");
            //プレイヤーマネージャーに報告
            manager.DamageReport();
            //タイマー初期化
            this.damageDelta = 0;
        }
        //衝突したものが攻撃なのかを調べる
        //連続で衝突を呼び出さないようスパンを設ける
        if(other.tag == this.ItemTag && this.itemDelta > this.itemGetSpan)
        {
            Debug.Log("アイテムと衝突");
            //プレイヤーマネージャーに報告
            manager.ItemGetReport();
            //タイマー初期化
            this.itemDelta = 0;
        }
    }

}
