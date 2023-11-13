using UnityEngine;

/// <summary>
/// プレイヤーの接地を判定クラス
/// </summary>
public class GroudCheck : MonoBehaviour
{
    // タグ名定数
    const string GroundTagName     = "Ground";     // 地面のタグ名定数
    const string TurnGroundTagName = "TurnGround"; // 回転可能な地面のタグ名定数

    // フラグ
    bool standGroundFlg     = true;  // 地面の接地フラグ
    bool standTurnGroundFlg = false; // 回転地面の接地フラグ

    Vector3 turnGroundPosition;      // 回転地面の座標保存変数

    /// <summary>
    /// 接地を受け取りフラグを立てる
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        // 接地した地面の種類を調べる
        if (other.tag == GroundTagName)
        {
            // 通常の地面の処理
            standGroundFlg = true;
        }
        else if(other.tag == TurnGroundTagName)
        {
            // 回転可能な地面の処理
            standTurnGroundFlg = true;                     // 回転地面との接地フラグを立てる
            standGroundFlg     = true;                     // 接地フラグを立てる
            turnGroundPosition = other.transform.position; // 座標を保持
        }
    }

    /// <summary>
    /// 判定がなくなったらフラグを下ろす
    /// </summary>
    void OnTriggerExit(Collider other)
    {
        // 衝突したものが地面なのかを調べる
        if (other.tag == GroundTagName)
        {
            standGroundFlg = false;
        }
        else if (other.tag == TurnGroundTagName)
        {
            standGroundFlg     = false;
            standTurnGroundFlg = false;
        }
    }
    /// <summary>
    /// プレイヤーが地面に立っているかのフラグを返す
    /// </summary>
    public bool GetGroundStandFlg()
    {
        return standGroundFlg;
    }

    /// <summary>
    /// プレイヤーが回転地面に立っているかのフラグを返す
    /// </summary>
    public bool GetTurnGroundStandFlg()
    {
        return standTurnGroundFlg;
    }

    /// <summary>
    /// 回転地面の座標を渡す
    /// </summary>
    public Vector3 GetTurnGroundPos()
    {
        return turnGroundPosition;
    }
}
