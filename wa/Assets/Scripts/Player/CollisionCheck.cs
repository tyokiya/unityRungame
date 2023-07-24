using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// プレイヤーの被弾を管理するスクリプト
////////////////////////////////////

public class CollisionCheck : MonoBehaviour
{
    //アイテムのタグ名
    string ItemTag = "Item";

    //アイテムタイマー
    float itemDelta = 0;
    //次のアイテムを獲得するまでのスパン
    float itemGetSpan = 0.05f;

    //インスペクターから設定
    //プレイヤーマネージャーのスクリプト
    public PlayerManager manager;
    //スコアマネージャー
    public SucoreManager sucoreManager;


    private void Update()
    {
        //タイマーの増加
        this.itemDelta += Time.deltaTime;

        //オーバーフローさせない処理
        if(this.itemDelta > float.MaxValue)
        {
            this.itemDelta = 0;
        }
    }

    /// <summary>
    /// 衝突を感知しマネージャーに知らせる
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //衝突したものがアイテムなのかを調べる
        //連続で衝突を呼び出さないようスパンを設ける
        if(other.tag == this.ItemTag && this.itemDelta > this.itemGetSpan)
        {
            Debug.Log("アイテムと衝突");
            //プレイヤーマネージャーに報告
            sucoreManager.ItemGetReport();
            //タイマー初期化
            this.itemDelta = 0;
            //獲得したアイテムオブジェクトを破壊
            Destroy(other.gameObject);
        }
    }

}
