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
    //壁のタグ名
    string wallTag = "wall";

    //アイテムタイマー
    float itemDelta = 0;
    //次のアイテムを獲得するまでのスパン
    float itemGetSpan = 0.05f;

    //壁との衝突フラグ
    bool collisionFlg = false;

    //インスペクターから設定
    //プレイヤーマネージャーのスクリプト
    [SerializeField] PlayerManager manager;
    //スコアマネージャー
    [SerializeField] ScoreManager scoreManager;

    void Update()
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
    void OnTriggerEnter(Collider other)
    {
        //衝突したものがアイテムなのかを調べる
        //連続で衝突を呼び出さないようスパンを設ける
        if(other.tag == this.ItemTag && this.itemDelta > this.itemGetSpan)
        {
            //Debug.Log("アイテムと衝突");
            //プレイヤーマネージャーに報告
            scoreManager.ItemGetReport();
            //タイマー初期化
            this.itemDelta = 0;
            //獲得したアイテムオブジェクトを破壊
            Destroy(other.gameObject);
        }
    }

    /// <summary>
    /// 衝突を検知しフラグを立てる
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision other)
    {
        //衝突したものが壁なのかを調べる
        if (other.gameObject.tag == this.wallTag)
        {
            //衝突フラグを立てる
            this.collisionFlg = true;
            Debug.Log("衝突");
        }
    }

    /// <summary>
    /// 衝突フラグを返す
    /// </summary>
    /// <returns>プレイヤーの壁との衝突フラグ</returns>
    public bool GetCollisionFlg()
    {
        return this.collisionFlg;
    }
}
