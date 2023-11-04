using UnityEngine;

/// <summary>
/// クレジットシーンのマネージャークラス
/// </summary>
public class CreditSceneManager : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] SceneController_CreditScene sceneController;  // シーンコントローラークラス
    [SerializeField] SoundController_CreditScene soundController;  // サウンドコントローラークラス
    [SerializeField] TapEffectController         effectController; // エフェクトコントローラークラス
    [SerializeField] ScreenInput_TittleScene     screenInput;      // 入力を感知するクラス

    void Update()
    {
        // プレイヤーからの入力があるか確認
        if (screenInput.TapFlgGetter())
        {
            // 座標を受け取りエフェクトの表示命令
            Vector3 pos = screenInput.TapPosGetter();
            effectController.PlyTapEffect(pos);
        }
    }

    /// <summary>
    /// バックボタンが押されたことを受け取りそれぞれに命令
    /// </summary>
    public void Down_BackButton()
    {        
        soundController.PlySelectSound();                     // セレクトサウンド再生命令        
        StartCoroutine(sceneController.ChangeScene_Tittle()); // シーン切り替え命令
    }
}
