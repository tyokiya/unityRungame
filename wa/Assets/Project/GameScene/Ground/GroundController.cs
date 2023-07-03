using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// 地面のコントローラースクリプト
////////////////////////////////////

public class GroundController : MonoBehaviour
{
    void Update()
    {
        GameObject camera;
        //カメラオブジェクト保持
        camera = GameObject.Find("Main Camera");

        //地面がプレイヤーより後ろに出た時点で破棄
        if(camera.transform.position.z > transform.position.z + 5.0f)
        {
            //オブジェクト破棄
            Destroy(gameObject);
        }
    }
}
