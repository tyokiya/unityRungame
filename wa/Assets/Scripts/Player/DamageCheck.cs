using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// プレイヤーの被弾を管理するスクリプト
////////////////////////////////////

public class DamageCheck : MonoBehaviour
{
    //攻撃のタグ名
    string attackTag = "Attack";

    //タイマー
    float delta = 0;
    //移動可能タイミングのスパン
    float damageSpan = 0.5f;

    //インスペクターから設定
    //プレイヤーマネージャーのスクリプト
    public PlayerManager manager;

    private void Update()
    {
        //デルタタイムの増加
        this.delta += Time.deltaTime;
    }

    /// <summary>
    /// 衝突を感知しマネージャーに知らせる
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //衝突したものが地面なのかを調べる
        //連続で衝突を呼び出さないようスパンを設ける
        if (other.tag == attackTag && this.delta > this.damageSpan)
        {
            //Debug.Log("攻撃と衝突");
            manager.DamageReportAcceptance();
            //タイマー初期化
            this.delta = 0;
        }
    }

}
