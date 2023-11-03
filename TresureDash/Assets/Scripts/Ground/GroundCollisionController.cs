using UnityEngine;

////////////////////////////////////
// 地面のコントローラースクリプト
////////////////////////////////////

/// <summary>
/// 地面の衝突を管理するクラス
/// </summary>
public class GroundCollisionController : MonoBehaviour
{
    [Tooltip("プレイヤーのタグ名の定数")]
    const string PlayerTagName = "Player";

    [SerializeField] GameObject ParentObject;

    // オブジェクト破壊までの待機時間
    const float WaitTimeObjectDestroy = 4.0f;

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
