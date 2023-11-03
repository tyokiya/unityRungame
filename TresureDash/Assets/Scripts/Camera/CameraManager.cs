using UnityEngine;

/// <summary>
/// カメラを管理するマネージャークラス
/// </summary>
public class CameraManager : MonoBehaviour
{
    //インスペクターから設定
    [Tooltip("入力状態を返すオブジェクト")][SerializeField]
    ScreenInput screenInput_object;

    [Tooltip("カメラの動きを管理するオブジェクト")][SerializeField] 
    CameraController controller_object;
    
    [Tooltip("プレイヤーの状態を返すオブジェクト")][SerializeField]
    Status playerStatus_object;
    
    [Tooltip("プレイヤーオブジェクト")][SerializeField]
    GameObject player;

    [Tooltip("現在の入力状態")]
    ScreenInput.FlickDirection nowFlick;

    [Tooltip("現在のプレイヤーの向いてる方向")]
    Status.PlayerDirection nowDirection;

    [Tooltip("現在のプレイヤーの状態")]
    Status.PlayerState nowSituation;

    void Update()
    {
        //プレイヤーの座標を取得
        Vector3 playerPos = this.player.transform.position;
        //現在のプレイヤーの向いてる方向を受け取る
        this.nowDirection = this.playerStatus_object.GetNowPlayerDirection();
        //現在のプレイヤーの状態を受け取る
        this.nowSituation = this.playerStatus_object.GetNowPlayerSituation();
        //フリック方向を受け取る
        this.nowFlick     = this.screenInput_object.GetNowFlick();

        //カメラの更新処理命令
        this.controller_object.UpdateCamera(playerPos, nowDirection, nowSituation);
    }

}
