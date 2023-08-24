using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditSceneManager : MonoBehaviour
{
    //インスペクターから設定
    [Tooltip("シーンコントローラーオブジェクト")][SerializeField] 
    SceneController_CreditScene sceneController_object;

    [Tooltip("サウンドコントローラーオブジェクト")][SerializeField]
    SoundController_CreditScene soundCOntroller_object;

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
