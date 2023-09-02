using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// アイテムの動きを制御するスクリプト
////////////////////////////////////
public class ItemController : MonoBehaviour
{
    [Tooltip("アイテムのy軸回転スピード定数")]
    const float rotateSpeed_y = 10.0f;
    void Update()
    {
        //一定の速度で回転
        transform.eulerAngles += new Vector3(0, rotateSpeed_y, 0);
    }
}
