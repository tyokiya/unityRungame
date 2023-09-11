using System.Collections;
using System.Collections.Generic;
using UniJSON;
using UnityEngine;
////////////////////////////////////
// タイトルシーンのカメラコントローラー
////////////////////////////////////

public class CameraController_TittleScene : MonoBehaviour
{
    float moveSpeed_x = 0.05f;
    float moveSpeed_z = 0.05f;

    float turnAngleSpeed = 0.5625f;

    int rotationCnt = 0;

    int frameCnt = 0;

    const float moveSpeed_const = 0.05f;

    void Update()
    {
        //カウント増加
        this.frameCnt++;

        //カウント数に応じて移動方向回転方向の変更
        if (this.rotationCnt % 640 == 0)
        {
            this.moveSpeed_x = moveSpeed_const;
            this.moveSpeed_z = moveSpeed_const;
            //カウント初期化
            this.rotationCnt = 0;
        }
        else if (this.rotationCnt % 480 == 0)
        {
            this.moveSpeed_x = moveSpeed_const;
            this.moveSpeed_z = -moveSpeed_const;
        }
        else if (this.rotationCnt % 320 == 0)
        {
            this.moveSpeed_x = -moveSpeed_const;
            this.moveSpeed_z = -moveSpeed_const;
        }
        else if (this.rotationCnt % 160 == 0)
        {
            this.moveSpeed_x = -moveSpeed_const;
            this.moveSpeed_z = moveSpeed_const;
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
