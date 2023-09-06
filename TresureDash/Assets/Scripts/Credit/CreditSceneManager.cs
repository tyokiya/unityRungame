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

    [Tooltip("エフェクトのコントローラーオブジェクト")]
    [SerializeField]
    TapEffectController effectController_object;

    [Tooltip("クレジットシーンシーンの入力を受けるオブジェクト")]
    [SerializeField]
    ScreenInput_TittleScene screenInput_object;

    void Update()
    {
        //プレイヤーからの入力があるか確認
        if (this.screenInput_object.TapFlgGetter())
        {
            //座標を受け取りエフェクトの表示命令
            Vector3 pos = this.screenInput_object.TapPosGetter();
            this.effectController_object.PlyTapEffect(pos);
        }
    }

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
