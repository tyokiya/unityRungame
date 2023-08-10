using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

////////////////////////////////////
// チュートリアルページのコントローラー
////////////////////////////////////

public class TutorialPage_controller : MonoBehaviour
{
    //インスペクターから設定
    //バックページボタンオブジェクト
    [SerializeField] GameObject backPageButton_object;
    //ネクストページボタンオブジェクト
    [SerializeField] GameObject nextPageButton_object;
    //チュートリアルページのオブジェクト
    [SerializeField] GameObject tutorialPage_1_object;
    [SerializeField] GameObject tutorialPage_2_object;
    [SerializeField] GameObject tutorialPage_3_object;
    [SerializeField] GameObject tutorialPage_4_object;
    [SerializeField] GameObject tutorialPage_5_object;


    void Awake()
    {
        //不要なUIの非表示
        this.backPageButton_object.SetActive(false);
    }

    /// <summary>
    /// 表示するチュートリアルページの更新
    /// </summary>
    /// <param name="nowPageNum">現在のチュートリアルページ数</param>
    public void PageActiveUpdate(int nowPageNum)
    {
        //初めのページ最後のページの場合は(次へ)(前へ)のボタン表示を消す
        switch (nowPageNum)
        {
            case 1:
                this.backPageButton_object.SetActive(false);
                break;
            case 5:
                this.nextPageButton_object.SetActive(false);
                break;
            default:
                this.backPageButton_object.SetActive(true);
                this.nextPageButton_object.SetActive(true);
                break;
        }

        //引数に応じて表示するページの変更
        switch (nowPageNum)
        {
            case 1:
                this.tutorialPage_1_object.SetActive(true);
                this.tutorialPage_2_object.SetActive(false);
                break;
            case 2:
                this.tutorialPage_1_object.SetActive(false);
                this.tutorialPage_2_object.SetActive(true);
                this.tutorialPage_3_object.SetActive(false);
                break;
            case 3:
                this.tutorialPage_2_object.SetActive(false);
                this.tutorialPage_3_object.SetActive(true);
                this.tutorialPage_4_object.SetActive(false);
                break;
            case 4:
                this.tutorialPage_3_object.SetActive(false);
                this.tutorialPage_4_object.SetActive(true);
                this.tutorialPage_5_object.SetActive(false);
                break;
            case 5:
                this.tutorialPage_4_object.SetActive(false);
                this.tutorialPage_5_object.SetActive(true);
                break;
        }
    }
}
