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

    [Tooltip("サウンドコントローラーオブジェクト")][SerializeField]
    SoundCOntroller_TittleScene soundCOntroller_object;

    [Tooltip("エフェクトのコントローラーオブジェクト")][SerializeField]
    TapEffectController effectController_object;

    [Tooltip("タイトルシーンの入力を受けるオブジェクト")][SerializeField]
    ScreenInput_TittleScene screenInput_object;

    void Update()
    {
        //プレイヤーからの入力があるか確認
        if(this.screenInput_object.TapFlgGetter())
        {
            //座標を受け取りエフェクトの表示命令
            Vector3 pos = this.screenInput_object.TapPosGetter();
            this.effectController_object.PlyTapEffect(pos);
        }
    }

    /// <summary>
    /// ゲームスタートボタンが押されたことを受け取りそれぞれに命令
    /// </summary>
    public void Down_GameStartButton()
    {
        //セレクトサウンド再生命令
        this.soundCOntroller_object.PlySelectSound();
        //シーン切り替えコルーチン
        StartCoroutine(this.sceneController_object.ChangeScene_Game());
    }

    /// <summary>
    /// チュートリアルボタンが押されたことを受け取りそれぞれに命令
    /// </summary>
    public void Down_TutorialButton()
    {
        //セレクトサウンド再生命令
        this.soundCOntroller_object.PlySelectSound();
        //シーン切り替えコルーチン
        StartCoroutine(this.sceneController_object.ChangeScene_Tutorial());    
    }

    public void Down_CreditButton()
    {
        //セレクトサウンド再生命令
        this.soundCOntroller_object.PlySelectSound();
        //シーン切り替えコルーチン
        StartCoroutine(this.sceneController_object.ChangeScene_Credit());
    }
}
