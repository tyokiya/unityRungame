using UnityEngine;

/// <summary>
/// チュートリアルシーンのマネージャークラス
/// </summary>
public class TutorialScene_Manager : MonoBehaviour
{
    // インスペクターから設定    
    [Tooltip("シーンコントローラーオブジェクト")][SerializeField]
    SceneController_TutorialScene sceneController_object;

    [Tooltip("サウンドコントローラーオブジェクト")][SerializeField]
    SoundCOntroller_TutorialScene soundCOntroller_object;
    
    [Tooltip("ページコントローラーオブジェクト")][SerializeField] 
    TutorialPage_controller pageController_object;

    [Tooltip("エフェクトのコントローラーオブジェクト")]
    [SerializeField]
    TapEffectController effectController_object;

    [Tooltip("チュートリアルシーンシーンの入力を受けるオブジェクト")]
    [SerializeField]
    ScreenInput_TittleScene screenInput_object;

    [Tooltip("現在の開いてるページのカウンター")]
    int nowPageNum = 1;

    void Update()
    {
        // プレイヤーからの入力があるか確認
        if (this.screenInput_object.TapFlgGetter())
        {
            // 座標を受け取りエフェクトの表示命令
            Vector3 pos = this.screenInput_object.TapPosGetter();
            this.effectController_object.PlyTapEffect(pos);
        }
    }

    /// <summary>
    /// バックボタンが押されたことを受け取りそれぞれに命令
    /// </summary>
    public void Down_BackButton()
    {
        // セレクトサウンド再生命令
        this.soundCOntroller_object.PlySelectSound();
        // シーン切り替え命令
        StartCoroutine(this.sceneController_object.ChangeScene_Tittle());
    }

    /// <summary>
    /// ネクストページボタンが押されたことを受け取りそれぞれに命令
    /// </summary>
    public void Down_NextPageButton()
    {
        // カウンターの増加
        this.nowPageNum++;
        // セレクトサウンド再生命令
        this.soundCOntroller_object.PlyPageSound();
        // ページのアクティブ状態の更新
        this.pageController_object.PageActiveUpdate(this.nowPageNum);
    }

    /// <summary>
    /// バックページボタンが押されたことを受け取りそれぞれに命令
    /// </summary>
    public void Down_BackPageButton()
    {
        // カウンターの減少
        this.nowPageNum--;
        // セレクトサウンド再生命令
        this.soundCOntroller_object.PlyPageSound();
        // ページのアクティブ状態の更新
        this.pageController_object.PageActiveUpdate(this.nowPageNum);
    }
}
