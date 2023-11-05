using UnityEngine;

/// <summary>
/// リザルトシーンのマネージャークラス
/// </summary>
public class ResultSceneManager : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] SceneController_ResultScene sceneController;  // シーンコントローラークラス
    [SerializeField] SoundController_ResultScene soundController;  // サウンドコントローラークラス
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
    /// ボタン入力を受け取りシーン切り替え命令
    /// </summary>
    public void ReStartButtonDown()
    {
        // ゲームシーンへ切り替え
        sceneController.ChangeScene_Game();
        // セレクト音再生
        soundController.PlySelectSound();
    }
    public void TittleButtonDown()
    { 
        // タイトルシーンへの切り替え
        sceneController.ChangeScene_Tittle();
        // セレクト音再生
        soundController.PlySelectSound();
    }
}
