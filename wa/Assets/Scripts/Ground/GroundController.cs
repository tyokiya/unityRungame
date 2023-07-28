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
    [SerializeField] GameObject ParentObject;

    /// <summary>
    /// プレイヤーとのを受け取りオブジェクト破壊のコルーチン呼び出し
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        //衝突したものがプレイヤーなのかを調べる
        if (other.tag == this.playerTag)
        {
            StartCoroutine(GroundDestroyCoroutine());
        }
    }

    /// <summary>
    /// プレイヤーが触れた地面を時間経過で破壊する
    /// </summary>

    public IEnumerator GroundDestroyCoroutine()
    {
        //4秒待機
        yield return new WaitForSeconds(4f);
        //Debug.Log("グラウンドコルーチン実行");
        Destroy(ParentObject);
    }
}
