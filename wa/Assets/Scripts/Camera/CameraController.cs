using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Status;

////////////////////////////////////
// カメラのコントローラースクリプト
////////////////////////////////////

public class CameraController : MonoBehaviour
{
    //カメラとプレイヤーの一定距離
    float playerDistance = 3.5f;

    //タイマー
    float delta = 0;
    //回転可能タイミングのスパン
    float rotationSpan = 0.1f;

    void Update()
    {
        //delta増加
        this.delta += Time.deltaTime;

    }

    /// <summary>
    /// カメラの情報更新
    /// </summary>
    /// <param name="playerPos">現在のプレイヤーの座標</param>
    /// <param name="flick">現在の入力状態</param>
    public void UpdateCamera(Vector3 playerPos, ScreenInput.FlickDirection flick)
    {
        //フリックに応じて処理
        switch (flick)
        {
            case ScreenInput.FlickDirection.RIGHT:          //右に向く処理
                RotationCamera(true);
                break;
            case ScreenInput.FlickDirection.LEFT:           //左に向く処理
                RotationCamera(false);
                break;
        }

        //常に一定の距離を保ちながらプレイヤーを追従
        transform.position = new Vector3(transform.position.x, transform.position.y, playerPos.z - playerDistance);

    }

    /// <summary>
    /// カメラの向き回転処理
    /// </summary>
    /// <param name="rightFlg">右に回転する場合のフラグ</param>
    void RotationCamera(bool rightFlg)
    {
        //フラグで回転の向き指定
        //連続で処理されないようにスパンを設ける
        if(rightFlg == true && this.delta > this.rotationSpan )
        {
            //右を向かせる　
            transform.eulerAngles = new Vector3(0, 90.0f, 0);
            //delta初期化
            this.delta = 0;
        }
        else if(rightFlg == false && this.delta > this.rotationSpan)
        {
            //左を向かせる　
            transform.eulerAngles = new Vector3(0, -90.0f, 0);
            //delta初期化
            this.delta = 0;
        }
    }
}
