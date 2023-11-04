using UnityEngine;

/// <summary>
/// カメラを管理するマネージャークラス
/// </summary>
public class CameraManager : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] ScreenInput      screenInput_object;  // 入力状態を返すオブジェクト
    [SerializeField] CameraController controller_object;   // カメラの動きを管理するオブジェクト
    [SerializeField] Status           playerStatus_object; // プレイヤーの状態を返すオブジェクト
    [SerializeField] GameObject       player;              // プレイヤーオブジェクト

    ScreenInput.FlickDirection nowFlick;       // 現在の入力状態
    Status.PlayerDirection nowPlayerDirection; // 現在のプレイヤーの向いてる方向
    Status.PlayerState nowPlayerState;         // 現在のプレイヤーの状態

    void Update()
    {
        // カメラの更新処理に必要な情報を受け取り更新命令
        Vector3 playerPos = player.transform.position;                                 // プレイヤーの座標を取得      
        nowPlayerDirection = playerStatus_object.GetNowPlayerDirection();              // 現在のプレイヤーの向いてる方向を受け取る        
        nowPlayerState = playerStatus_object.GetNowPlayerSituation();                  // 現在のプレイヤーの状態を受け取る       
        nowFlick = screenInput_object.GetNowFlick();                                   // フリック方向を受け取る       
        controller_object.UpdateCamera(playerPos, nowPlayerDirection, nowPlayerState); // カメラの更新処理命令
    }

}
