using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// カメラを管理するマネージャースクリプト
////////////////////////////////////

public class CameraManager : MonoBehaviour
{
    //インスペクターから設定
    //入力状態を返すスクリプト
    public ScreenInput screenInput;
    //カメラの動きを管理するスクリプト
    public CameraController controller;

    //プレイヤーオブジェクトを入れる変数
    GameObject player;
    //現在の入力状態を入れる変数
    ScreenInput.FlickDirection nowFlick;

    void Awake()
    {
        //代入
        this.player = GameObject.Find("Player");
    }

    void Update()
    {
        //プレイヤーの座標を取得
        Vector3 playerPos = this.player.transform.position;
        //フリック方向を受け取る
        this.nowFlick = this.screenInput.GetNowFlick();

        //カメラの更新処理命令
        this.controller.UpdateCamera(playerPos, nowFlick);

    }

}
