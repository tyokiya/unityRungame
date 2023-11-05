using UnityEngine;

/// <summary>
/// チュートリアルページのコントローラークラス
/// </summary>
public class TutorialPage_controller : MonoBehaviour
{
    // インスペクターから設定    
    [SerializeField] GameObject backPageButton; // バックページボタンオブジェクト
    [SerializeField] GameObject nextPageButton; // ネクストページボタンオブジェクト
    // チュートリアルページのオブジェクト
    [SerializeField] GameObject tutorialPage_1_object;
    [SerializeField] GameObject tutorialPage_2_object;
    [SerializeField] GameObject tutorialPage_3_object;
    [SerializeField] GameObject tutorialPage_4_object;
    [SerializeField] GameObject tutorialPage_5_object;

    void Awake()
    {
        // 不要なUIの非表示
        backPageButton.SetActive(false);
    }

    /// <summary>
    /// 表示するチュートリアルページの更新
    /// </summary>
    /// <param name="nowPageNum">現在のチュートリアルページ数</param>
    public void PageActiveUpdate(int nowPageNum)
    {
        // 初めのページ最後のページの場合は(次へ)(前へ)のボタン表示を消す
        switch (nowPageNum)
        {
            case 1:
                backPageButton.SetActive(false);
                break;
            case 5:
                nextPageButton.SetActive(false);
                break;
            default:
                backPageButton.SetActive(true);
                nextPageButton.SetActive(true);
                break;
        }

        // 引数に応じて表示するページの変更
        switch (nowPageNum)
        {
            case 1:
                tutorialPage_1_object.SetActive(true);
                tutorialPage_2_object.SetActive(false);
                break;
            case 2:
                tutorialPage_1_object.SetActive(false);
                tutorialPage_2_object.SetActive(true);
                tutorialPage_3_object.SetActive(false);
                break;
            case 3:
                tutorialPage_2_object.SetActive(false);
                tutorialPage_3_object.SetActive(true);
                tutorialPage_4_object.SetActive(false);
                break;
            case 4:
                tutorialPage_3_object.SetActive(false);
                tutorialPage_4_object.SetActive(true);
                tutorialPage_5_object.SetActive(false);
                break;
            case 5:
                tutorialPage_4_object.SetActive(false);
                tutorialPage_5_object.SetActive(true);
                break;
        }
    }
}
