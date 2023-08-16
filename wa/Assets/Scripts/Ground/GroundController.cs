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
    /// プレイヤーとのを受け取りオブジェクト破壊処理
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        //衝突したものがプレイヤーなのかを調べる
        if (other.tag == this.playerTag)
        {
            //4秒後オブジェクトを破壊
            Destroy(ParentObject,4.0f);
        }
    }
}
