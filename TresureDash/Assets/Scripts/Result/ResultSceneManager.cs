using UnityEngine;

/// <summary>
/// リザルトシーンのマネージャークラス
/// </summary>
public class ResultSceneManager : MonoBehaviour
{
    // インスペクターから設定
    [Tooltip("シーンコントローラーオブジェクト")][SerializeField]
    SceneController_ResultScene sceneController_object;

    [Tooltip("サウンドコントローラーオブジェクト")][SerializeField]
    SoundController_ResultScene soundController_object;

    [Tooltip("エフェクトのコントローラーオブジェクト")][SerializeField]
    TapEffectController effectController_object;

    [Tooltip("リザルトシーンシーンの入力を受けるオブジェクト")][SerializeField]
    ScreenInput_TittleScene screenInput_object;

    void Update()
    {
        // プレイヤーからの入力があるか確認
        if (this.screenInput_object.TapFlgGetter())
        {
            //座標を受け取りエフェクトの表示命令
            Vector3 pos = this.screenInput_object.TapPosGetter();
            this.effectController_object.PlyTapEffect(pos);
        }
    }

    /// <summary>
    /// ボタン入力を受け取りシーン切り替え命令
    /// </summary>
    public void ReStartButtonDown()
    {
        // ゲームシーンへ切り替え
        this.sceneController_object.ChangeScene_Game();
        // セレクト音再生
        this.soundController_object.PlySelectSound();
    }
    public void TittleButtonDown()
    { 
        // タイトルシーンへの切り替え
        this.sceneController_object.ChangeScene_Tittle();
        // セレクト音再生
        this.soundController_object.PlySelectSound();
    }
}
