using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// チュートリアルシーンのマネージャースクリプト
////////////////////////////////////

public class TutorialScene_Manager : MonoBehaviour
{
    //インスペクターから設定
    //シーンコントローラー
    [SerializeField] SceneController_TutorialScene sceneController_object;
    //サウンドコントローラー
    [SerializeField] SoundCOntroller_TutorialScene soundCOntroller_object;

    /// <summary>
    /// バックボタンが押されたことを受け取りそれぞれに命令
    /// </summary>
    public void Down_BackButton()
    {
        //セレクトサウンド再生命令
        this.soundCOntroller_object.PlySelectSound();
        //シーン切り替え命令
        StartCoroutine(this.sceneController_object.ChangeScene_Tittle());
    }
}
