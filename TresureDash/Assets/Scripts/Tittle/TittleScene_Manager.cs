using System.Collections;
using UnityEngine;

/// <summary>
/// タイトルシーンのマネージャークラス
/// </summary>
public class TittleScene_Manager : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] SceneController_TittleScene sceneController; // シーンコントローラークラス
    [SerializeField] SoundCOntroller_TittleScene soundController; // サウンドコントローラークラス
    [SerializeField] TapEffectController effectController_object; // エフェクトコントローラークラス
    [SerializeField] ScreenInput_TittleScene screenInput_object;  // 入力を感知するクラス
    [SerializeField] Fade fade_obj;                             　// フェード処理オブジェクト

    // 定数
    const int fadeTime = 3; // フェード所要時間定数

    void Start()
    { 
        // 画面のフェードイン処理
        fade_obj.FadeIn(fadeTime);
    }

    void Update()
    {
        // プレイヤーからの入力があるか確認
        if(screenInput_object.TapFlgGetter())
        {
            // 座標を受け取りエフェクトの表示命令
            Vector3 pos = screenInput_object.TapPosGetter();
            effectController_object.PlyTapEffect(pos);
        }
    }

    /// <summary>
    /// ゲームスタートボタンが押されたことを受け取りそれぞれに命令
    /// </summary>
    public void Down_GameStartButton()
    {
        // フェードアウト処理
        fade_obj.FadeOut(fadeTime);
        // シーン切り替えコルーチン
        StartCoroutine(ChangeGameScene());
    }

    /// <summary>
    /// ゲームシーンへの切り替えコルーチン
    /// </summary>
    IEnumerator ChangeGameScene()
    {
        // セレクトサウンド再生命令
        soundController.PlySelectSound();

        // フェードアウトの時間分待機
        yield return new WaitForSeconds(fadeTime);
        
        // シーン切り替えコルーチン
        StartCoroutine(sceneController.ChangeScene_Game());
    }

    /// <summary>
    /// チュートリアルボタンが押されたことを受け取りそれぞれに命令
    /// </summary>
    public void Down_TutorialButton()
    {
        // セレクトサウンド再生命令
        soundController.PlySelectSound();
        // シーン切り替えコルーチン
        StartCoroutine(sceneController.ChangeScene_Tutorial());    
    }

    public void Down_CreditButton()
    {
        // セレクトサウンド再生命令
        soundController.PlySelectSound();
        // シーン切り替えコルーチン
        StartCoroutine(sceneController.ChangeScene_Credit());
    }
}
