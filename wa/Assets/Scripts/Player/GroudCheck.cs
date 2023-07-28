using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// 地面の衝突を管理するスクリプト
////////////////////////////////////

public class GroudCheck : MonoBehaviour
{
    //地面のタグ名
    string groundTag = "Ground";
    string turnGroundTag = "TurnGround";
    //地面に立っているか
    bool standGroundFlg = true;
    bool standTurnGroundFlg = false;

    /// <summary>
    /// 衝突を受け取りフラグを立てる
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        //衝突したものが地面なのかを調べる
        if (other.tag == this.groundTag)
        {
            this.standGroundFlg = true;
            //Debug.Log("1");

        }
        else if(other.tag == this.turnGroundTag)
        {
            this.standGroundFlg = true;
            this.standTurnGroundFlg = true;
        }
    }

    /// <summary>
    /// 判定がなくなったらフラグを下ろす
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        //衝突したものが地面なのかを調べる
        if (other.tag == this.groundTag)
        {
            this.standGroundFlg = false;
            //Debug.Log("2");
        }
        else if (other.tag == this.turnGroundTag)
        {
            this.standGroundFlg = false;
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
