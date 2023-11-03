using UnityEngine;

/// <summary>
/// プレイヤーの接地を判定クラス
/// </summary>
public class GroudCheck : MonoBehaviour
{
    [Tooltip("地面のタグ名定数")] 
    const string GroundTagName     = "Ground";
    [Tooltip("回転可能な地面のタグ名定数")]
    const string TurnGroundTagName = "TurnGround";

    [Tooltip("地面の接地フラグ")]
    bool standGroundFlg     = true;
    [Tooltip("回転地面の接地フラグ")]
    bool standTurnGroundFlg = false;

    /// <summary>
    /// 接地を受け取りフラグを立てる
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        //接地した地面の種類を調べる
        if (other.tag == GroundTagName)
        {
            //通常の地面の処理
            this.standGroundFlg = true;
        }
        else if(other.tag == TurnGroundTagName)
        {
            //回転可能な地面の処理
            this.standGroundFlg     = true;
            this.standTurnGroundFlg = true;
        }
    }

    /// <summary>
    /// 判定がなくなったらフラグを下ろす
    /// </summary>
    void OnTriggerExit(Collider other)
    {
        //衝突したものが地面なのかを調べる
        if (other.tag == GroundTagName)
        {
            this.standGroundFlg = false;
        }
        else if (other.tag == TurnGroundTagName)
        {
            this.standGroundFlg     = false;
            this.standTurnGroundFlg = false;
        }
    }
    /// <summary>
    /// プレイヤーが地面に立っているかのフラグを返す
    /// </summary>
    /// <returns></returns>
    public bool GetGroundStandFlg()
    {
        return standGroundFlg;
    }

    public bool GetTurnGroundStandFlg()
    {
        return standTurnGroundFlg;
    }
}
