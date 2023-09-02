using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// リザルトシーンのマネージャースクリプト
////////////////////////////////////
public class ResultSceneManager : MonoBehaviour
{
    //インスペクターから設定
    [Tooltip("シーンコントローラーオブジェクト")][SerializeField]
    SceneController_ResultScene sceneController_object;

    [Tooltip("サウンドコントローラーオブジェクト")][SerializeField]
    SoundController_ResultScene soundController_object;

    /// <summary>
    /// ボタン入力を受け取りシーン切り替え命令
    /// </summary>
    public void ReStartButtonDown()
    {
        //ゲームシーンへ切り替え
        this.sceneController_object.ChangeScene_Game();
        //セレクト音再生
        this.soundController_object.PlySelectSound();
    }
    public void TittleButtonDown()
    {
        //タイトルシーンへの切り替え
        this.sceneController_object.ChangeScene_Tittle();
        //セレクト音再生
        this.soundController_object.PlySelectSound();
    }
}
