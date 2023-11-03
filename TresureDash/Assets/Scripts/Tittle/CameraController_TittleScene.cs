using System.Collections;
using UnityEngine;

/// <summary>
/// タイトルシーンのカメラコントローラークラス
/// </summary>
public class CameraController_TittleScene : MonoBehaviour
{
    float moveSpeed_x = 0.05f;
    float moveSpeed_z = 0.05f;

    int rotationCnt = 0;
    int frameCnt    = 0;

    const float TurnAngleSpeed = 0.5625f;
    const float MoveSpeed      = 0.05f;

    void Update()
    {
        // カウント増加
        this.frameCnt++;

        // カウント数に応じて移動方向回転方向の変更
        if (this.rotationCnt % 640 == 0)
        {
            this.moveSpeed_x = MoveSpeed;
            this.moveSpeed_z = MoveSpeed;
            // カウント初期化
            this.rotationCnt = 0;
        }
        else if (this.rotationCnt % 480 == 0)
        {
            this.moveSpeed_x = MoveSpeed;
            this.moveSpeed_z = -MoveSpeed;
        }
        else if (this.rotationCnt % 320 == 0)
        {
            this.moveSpeed_x = -MoveSpeed;
            this.moveSpeed_z = -MoveSpeed;
        }
        else if (this.rotationCnt % 160 == 0)
        {
            this.moveSpeed_x = -MoveSpeed;
            this.moveSpeed_z = MoveSpeed;
        }

        // 移動処理
        if(frameCnt % 2 == 0)
        {
            // カウント増加
            this.rotationCnt++;
            // プレイヤーを中心に周りを回る移動処理
            transform.position = new Vector3(transform.position.x + this.moveSpeed_x, transform.position.y, transform.position.z + moveSpeed_z);
            // プレイヤーを中心にカメラのアングル追従処理
            transform.eulerAngles -= new Vector3(0, TurnAngleSpeed, 0);
        }        
    }
}
