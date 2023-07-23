using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// 地面のコントローラースクリプト
////////////////////////////////////

public class GroundController : MonoBehaviour
{
    //プレイヤーのタグ名
    string playerTag = "Player";
    //親オブジェクト
    GameObject ParentObject;

    void Awake()
    {
        //親オブジェクトを取得
        ParentObject = transform.root.gameObject;
    }

        /// <summary>
        /// プレイヤーとのを受け取りオブジェクト破壊のコルーチン呼び出し
        /// </summary>
        private void OnTriggerEnter(Collider other)
    {
        //衝突したものがプレイヤーなのかを調べる
        if (other.tag == this.playerTag)
        {
            //StartCoroutine(GroundDestroyCoroutine());
        }
    }

    /// <summary>
    /// プレイヤーが触れた地面を時間経過で破壊する
    /// </summary>

    public IEnumerator GroundDestroyCoroutine()
    {
        //3秒待機
        yield return new WaitForSeconds(3f);
        Debug.Log("グラウンドコルーチン実行");
        Destroy(ParentObject);
    }
}
