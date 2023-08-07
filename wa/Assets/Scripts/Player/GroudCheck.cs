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
    void OnTriggerEnter(Collider other)
    {
        //衝突した地面の種類を調べる
        if (other.tag == this.groundTag)
        {
            //通常の地面の処理
            this.standGroundFlg = true;
        }
        else if(other.tag == this.turnGroundTag)
        {
            //回転可能な地面の処理
            this.standGroundFlg = true;
            this.standTurnGroundFlg = true;
        }
    }

    /// <summary>
    /// 判定がなくなったらフラグを下ろす
    /// </summary>
    void OnTriggerExit(Collider other)
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
