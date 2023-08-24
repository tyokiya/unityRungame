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

    /// <summary>
    /// ボタン入力を受け取りシーン切り替え命令
    /// </summary>
    public void ReStartButtonDown()
    {
        //ゲームシーンへ切り替え
        this.sceneController_object.ChangeScene_Game();
    }
    public void TittleButtonDown()
    {
        //タイトルシーンへの切り替え
        this.sceneController_object.ChangeScene_Tittle();
    }
}
