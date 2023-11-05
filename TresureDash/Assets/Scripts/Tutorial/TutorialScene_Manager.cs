using UnityEngine;

/// <summary>
/// チュートリアルシーンのマネージャークラス
/// </summary>
public class TutorialScene_Manager : MonoBehaviour
{
    // インスペクターから設定     
    [SerializeField] SceneController_TutorialScene sceneController;  // シーンコントローラークラス
    [SerializeField] SoundCOntroller_TutorialScene soundController;  // サウンドコントローラークラス
    [SerializeField] TutorialPage_controller       pageController;   // ページコントローラークラス
    [SerializeField] TapEffectController           effectController; // エフェクトのコントローラークラス
    [SerializeField] ScreenInput_TittleScene       screenInput;　　　// 入力感知クラス

    // 現在の開いてるページのカウンター
    int nowPageNum = 1; 

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
        // セレクトサウンド再生命令
        soundController.PlySelectSound();
        // シーン切り替え命令
        StartCoroutine(sceneController.ChangeScene_Tittle());
    }

    /// <summary>
    /// ネクストページボタンが押されたことを受け取りそれぞれに命令
    /// </summary>
    public void Down_NextPageButton()
    {
        // カウンターの増加
        nowPageNum++;
        // セレクトサウンド再生命令
        soundController.PlyPageSound();
        // ページのアクティブ状態の更新
        pageController.PageActiveUpdate(nowPageNum);
    }

    /// <summary>
    /// バックページボタンが押されたことを受け取りそれぞれに命令
    /// </summary>
    public void Down_BackPageButton()
    {
        // カウンターの減少
        nowPageNum--;
        // セレクトサウンド再生命令
        soundController.PlyPageSound();
        // ページのアクティブ状態の更新
        pageController.PageActiveUpdate(nowPageNum);
    }
}
