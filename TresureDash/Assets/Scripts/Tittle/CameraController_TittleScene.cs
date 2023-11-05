using UnityEngine;

/// <summary>
/// タイトルシーンのカメラコントローラークラス
/// </summary>
public class CameraController_TittleScene : MonoBehaviour
{
    // 移動速度を入れる変数
    float moveSpeed_x = MoveSpeed; // x軸
    float moveSpeed_z = MoveSpeed; // z軸

    // カウンタ
    int rotationCnt = 0; // 回転カウンタ
    int frameCnt    = 0; // フレームカウンタ

    // 定数
    const float TurnAngleSpeed = 0.5625f; // 回転スピード
    const float MoveSpeed      = 0.05f;   // 移動スピード

    void Update()
    {
        // カウント増加
        frameCnt++;

        // カウント数に応じて移動方向回転方向の変更
        if (rotationCnt % 640 == 0)
        {
            moveSpeed_x = MoveSpeed;
            moveSpeed_z = MoveSpeed;
            // カウント初期化
            rotationCnt = 0;
        }
        else if (rotationCnt % 480 == 0)
        {
            moveSpeed_x = MoveSpeed;
            moveSpeed_z = -MoveSpeed;
        }
        else if (rotationCnt % 320 == 0)
        {
            moveSpeed_x = -MoveSpeed;
            moveSpeed_z = -MoveSpeed;
        }
        else if (rotationCnt % 160 == 0)
        {
            moveSpeed_x = -MoveSpeed;
            moveSpeed_z = MoveSpeed;
        }

        // 移動処理
        if(frameCnt % 2 == 0)
        {
            // カウント増加
            rotationCnt++;
            // プレイヤーを中心に周りを回る移動処理
            transform.position = new Vector3(transform.position.x + moveSpeed_x, transform.position.y, transform.position.z + moveSpeed_z);
            // プレイヤーを中心にカメラのアングル追従処理
            transform.eulerAngles -= new Vector3(0, TurnAngleSpeed, 0);
        }        
    }
}
