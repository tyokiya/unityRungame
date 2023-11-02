using UnityEngine;

////////////////////////////////////
// 地面のコントローラースクリプト
////////////////////////////////////

public class GroundController : MonoBehaviour
{
    [Tooltip("プレイヤーのタグ名の定数")]
    const string PlayerTagName = "Player";

    [SerializeField] GameObject ParentObject;

    /// <summary>
    /// プレイヤーとの衝突を受け取りオブジェクト破壊処理
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        //衝突したものがプレイヤーなのかを調べる
        if (other.tag == PlayerTagName)
        {
            //4秒後オブジェクトを破壊
            Destroy(ParentObject,4.0f);
        }
    }
}
