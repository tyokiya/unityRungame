using System.Collections;
using System.Collections.Generic;
using UniJSON;
using UnityEngine;
////////////////////////////////////
// タイトルシーンのカメラコントローラー
////////////////////////////////////

public class CameraController_TittleScene : MonoBehaviour
{
    //カメラの移動速度
    float moveSpeed_x = 0.05f;
    float moveSpeed_z = 0.05f;
    //カメラの回転スピード
    float turnAngleSpeed = 0.5625f;
    //回転カウント
    int rotationCnt = 0;
    //フレームカウント
    int frameCnt = 0;

    void Update()
    {
        //カウント増加
        this.frameCnt++;

        //カウント数に応じて移動方向回転方向の変更
        if (this.rotationCnt % 640 == 0)
        {
            this.moveSpeed_x = 0.05f;
            this.moveSpeed_z = 0.05f;
            //カウント初期化
            this.rotationCnt = 0;
        }
        else if (this.rotationCnt % 480 == 0)
        {
            this.moveSpeed_x = 0.05f;
            this.moveSpeed_z = -0.05f;
        }
        else if (this.rotationCnt % 320 == 0)
        {
            this.moveSpeed_x = -0.05f;
            this.moveSpeed_z = -0.05f;
        }
        else if (this.rotationCnt % 160 == 0)
        {
            this.moveSpeed_x = -0.05f;
            this.moveSpeed_z = 0.05f;
        }

        //移動処理
        if(frameCnt % 2 == 0)
        {
            //カウント増加
            this.rotationCnt++;
            //プレイヤーを中心に周りを回る移動処理
            transform.position = new Vector3(transform.position.x + this.moveSpeed_x, transform.position.y, transform.position.z + moveSpeed_z);
            //プレイヤーを中心にカメラのアングル追従処理
            transform.eulerAngles -= new Vector3(0, this.turnAngleSpeed, 0);
        }        
    }
}
