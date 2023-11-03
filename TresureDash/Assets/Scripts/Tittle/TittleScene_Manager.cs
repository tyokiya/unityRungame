using System.Collections;
using UnityEngine;

/// <summary>
/// タイトルシーンのマネージャークラス
/// </summary>
public class TittleScene_Manager : MonoBehaviour
{
    // インスペクターから設定
    [Tooltip("シーンコントローラーオブジェクト")][SerializeField] 
    SceneController_TittleScene sceneController_object;

    [Tooltip("サウンドコントローラーオブジェクト")][SerializeField]
    SoundCOntroller_TittleScene soundCOntroller_object;

    [Tooltip("エフェクトのコントローラーオブジェクト")][SerializeField]
    TapEffectController effectController_object;

    [Tooltip("タイトルシーンの入力を受けるオブジェクト")][SerializeField]
    ScreenInput_TittleScene screenInput_object;

    [SerializeField][Tooltip("フェード処理オブジェクト")]
    Fade fade_obj;

    [SerializeField][Tooltip("フェード所要時間定数")]
    int fade_time;

    void Start()
    { 
        // 画面のフェードイン処理
        this.fade_obj.FadeIn(fade_time);
    }

    void Update()
    {
        // プレイヤーからの入力があるか確認
        if(this.screenInput_object.TapFlgGetter())
        {
            // 座標を受け取りエフェクトの表示命令
            Vector3 pos = this.screenInput_object.TapPosGetter();
            this.effectController_object.PlyTapEffect(pos);
        }
    }

    /// <summary>
    /// ゲームスタートボタンが押されたことを受け取りそれぞれに命令
    /// </summary>
    public void Down_GameStartButton()
    {
        // フェードアウト処理
        fade_obj.FadeOut(fade_time);
        // シーン切り替えコルーチン
        StartCoroutine(ChangeGameScene());
    }

    /// <summary>
    /// ゲームシーンへの切り替えコルーチン
    /// </summary>
    IEnumerator ChangeGameScene()
    {
        // セレクトサウンド再生命令
        this.soundCOntroller_object.PlySelectSound();

        // フェードアウトの時間分待機
        yield return new WaitForSeconds(fade_time);
        
        // シーン切り替えコルーチン
        StartCoroutine(this.sceneController_object.ChangeScene_Game());
    }

    /// <summary>
    /// チュートリアルボタンが押されたことを受け取りそれぞれに命令
    /// </summary>
    public void Down_TutorialButton()
    {
        // セレクトサウンド再生命令
        this.soundCOntroller_object.PlySelectSound();
        // シーン切り替えコルーチン
        StartCoroutine(this.sceneController_object.ChangeScene_Tutorial());    
    }

    public void Down_CreditButton()
    {
        // セレクトサウンド再生命令
        this.soundCOntroller_object.PlySelectSound();
        // シーン切り替えコルーチン
        StartCoroutine(this.sceneController_object.ChangeScene_Credit());
    }
}
