using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

////////////////////////////////////
// 傾きの入力を受け取るスクリプト
////////////////////////////////////

public class GyroInput : MonoBehaviour
{
    //1フレーム前のスマホの傾きを入れる変数
    Vector3 old_input_tilt;
    //現在のスマホの傾きを入れる変数
    Vector3 input_tilt;

    void Awake()
    {
        Input.gyro.enabled = true;
    }

    void Update()
    {
        //1フレーム前の傾きを入れる
        this.old_input_tilt = input_tilt;
        //四元数を受け取る
        Quaternion quaternion = Input.gyro.attitude;
        //オイラー変換
        input_tilt = quaternion.eulerAngles;
        //this.input_tilt.y = Input.gyro.attitude.eulerAngles.y;

    }

    /// <summary>
    /// スマホの傾きを返す
    /// </summary>
    /// <returns></returns>
    public float GetDifferenceTilt()
    {
        //中心から傾いた値を返す
        return this.input_tilt.y - 35;
    }
}
