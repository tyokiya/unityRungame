using UnityEngine;

////////////////////////////////////
// 地面のコントローラースクリプト
////////////////////////////////////

/// <summary>
/// 地面の衝突を管理するクラス
/// </summary>
public class GroundCollisionController : MonoBehaviour
{
    [SerializeField] GameObject ParentObject; // アタッチ元の親オブジェクト

    const string PlayerTagName = "Player"; // プレイヤーのタグ名
    const float WaitTimeObjectDestroy = 4.0f; // オブジェクト破壊までの待機時間

    /// <summary>
    /// プレイヤーとの衝突を受け取りオブジェクト破壊処理
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        // 衝突したものがプレイヤーなのかを調べる
        if (other.tag == PlayerTagName)
        {
            // 4秒後オブジェクトを破壊
            Destroy(ParentObject, WaitTimeObjectDestroy);
        }
    }
}
