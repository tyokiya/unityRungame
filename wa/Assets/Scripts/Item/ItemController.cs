using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// アイテムの動きを制御するスクリプト
////////////////////////////////////
public class ItemController : MonoBehaviour
{
    //アイテムの回転スピード
    float rotateSpeed = 10.0f;

    void Update()
    {
        //一定の速度で回転
        transform.eulerAngles += new Vector3(0, this.rotateSpeed, 0);
    }
}
