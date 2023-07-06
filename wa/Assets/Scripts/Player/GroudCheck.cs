using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroudCheck : MonoBehaviour
{
    //地面のタグ名
    string groundTag = "Ground";
    //地面に立っているか
    bool StandGroundFlg = true;

    /// <summary>
    /// 衝突を受け取りフラグを立てる
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == groundTag)
        {
            this.StandGroundFlg = true;
        }
    }

    /// <summary>
    /// 判定がなくなったらフラグを下ろす
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        this.StandGroundFlg = false;
    }
    /// <summary>
    /// プレイヤーが地面に立っているかのフラグを返す
    /// </summary>
    /// <returns></returns>
    public bool GetGroundStandFlg()
    {
        return StandGroundFlg;
    }

}
