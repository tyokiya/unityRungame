using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// タイトルシーンのマネージャースクリプト
////////////////////////////////////

public class TittleScene_Manager : MonoBehaviour
{
    //インスペクターから設定
    [Tooltip("シーンコントローラーオブジェクト")][SerializeField] 
    SceneController_TittleScene sceneController_object;

    //サウンドコントローラー
    [Tooltip("サウンドコントローラーオブジェクト")][SerializeField]
    SoundCOntroller_TittleScene soundCOntroller_object;

    /// <summary>
    /// ゲームスタートボタンが押されたことを受け取りそれぞれに命令
    /// </summary>
    public void Down_GameStartButton()
    {
        //セレクトサウンド再生命令
        this.soundCOntroller_object.PlySelectSound();
        //シーン切り替え命令
        StartCoroutine(this.sceneController_object.ChangeScene_Game());
    }

    /// <summary>
    /// チュートリアルボタンが押されたことを受け取りそれぞれに命令
    /// </summary>
    public void Down_TutorialButton()
    {
        //セレクトサウンド再生命令
        this.soundCOntroller_object.PlySelectSound();
        //シーン切り替え命令
        StartCoroutine(this.sceneController_object.ChangeScene_Tutorial());    
    }

    public void Down_CreditButton()
    {
        //セレクトサウンド再生命令
        this.soundCOntroller_object.PlySelectSound();
        //シーン切り替え命令
        StartCoroutine(this.sceneController_object.ChangeScene_Credit());
    }
}
