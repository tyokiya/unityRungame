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
    //ゴールのタグ
    string goalTag = "GoalItem";

    //壁との衝突フラグ
    bool collisionFlg = false;

    //インスペクターから設定
    //プレイヤーマネージャーのスクリプト
    [SerializeField] PlayerManager playerManager;
    //スコアマネージャー
    [SerializeField] ScoreManager scoreManager;

    /// <summary>
    /// 衝突を感知しマネージャーに知らせる
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        //衝突したものがアイテムなのかを調べる
        if(other.tag == this.ItemTag)
        {
            //Debug.Log("アイテムと衝突");
            //プレイヤーマネージャーに報告
            this.playerManager.ItemGetReport();
            //スコアマネージャーに報告
            this.scoreManager.ItemGetReport();
            //獲得したアイテムオブジェクトを破壊
            Destroy(other.gameObject);
        }

        //衝突したものがゴールなのかを調べる
        if(other.tag == this.goalTag)
        {
            //プレイヤーマネージャーに報告
            this.playerManager.GoalReport();
            //獲得したゴールオブジェクトを破壊
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
            //Debug.Log("衝突");
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
