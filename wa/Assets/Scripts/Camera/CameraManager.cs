using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// カメラを管理するマネージャースクリプト
////////////////////////////////////

public class CameraManager : MonoBehaviour
{
    //インスペクターから設定
    //入力状態を返すオブジェクト
    public ScreenInput screenInput_object;
    //カメラの動きを管理するオブジェクト
    public CameraController controller_object;
    //現在のプレイヤー状態を返すオブジェクト
    public Status playerStatus_object;

    //プレイヤーオブジェクトを入れる変数
    GameObject player;
    //現在の入力状態を入れる変数
    ScreenInput.FlickDirection nowFlick;
    //現在のプレイヤーの向いてる方向を入れる変数
    Status.PlayerDirection nowDirection;
    //現在のプレイヤーの状態
    Status.PlayerSituation nowSituation;

    void Awake()
    {
        //代入
        this.player = GameObject.Find("Player");
    }

    void Update()
    {
        //プレイヤーの座標を取得
        Vector3 playerPos = this.player.transform.position;
        //現在のプレイヤーの向いてる方向を受け取る
        this.nowDirection = this.playerStatus_object.GetNowPlayerDirection();
        //現在のプレイヤーの状態を受け取る
        this.nowSituation = this.playerStatus_object.GetNowPlayerSituation();
        //フリック方向を受け取る
        this.nowFlick = this.screenInput_object.GetNowFlick();

        //カメラの更新処理命令
        this.controller_object.UpdateCamera(playerPos, nowDirection, nowSituation);

    }

}
