using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// チュートリアルシーンのマネージャースクリプト
////////////////////////////////////

public class TutorialScene_Manager : MonoBehaviour
{
    //インスペクターから設定
    //シーンコントローラー
    [SerializeField] SceneController_TutorialScene sceneController_object;
    //サウンドコントローラー
    [SerializeField] SoundCOntroller_TutorialScene soundCOntroller_object;
    //ページコントローラー
    [SerializeField] TutorialPage_controller pageController_object;

    //現在の開いているチュートリアルのページ数のカウンター
    int nowPageNum = 1;

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

    /// <summary>
    /// ネクストページボタンが押されたことを受け取りそれぞれに命令
    /// </summary>
    public void Down_NextPageButton()
    {
        //カウンターの増加
        this.nowPageNum++;
        //セレクトサウンド再生命令
        this.soundCOntroller_object.PlyPageSound();
        //ページのアクティブ状態の更新
        this.pageController_object.PageActiveUpdate(this.nowPageNum);
    }

    /// <summary>
    /// バックページボタンが押されたことを受け取りそれぞれに命令
    /// </summary>
    public void Down_BackPageButton()
    {
        //カウンターの減少
        this.nowPageNum--;
        //セレクトサウンド再生命令
        this.soundCOntroller_object.PlyPageSound();
        //ページのアクティブ状態の更新
        this.pageController_object.PageActiveUpdate(this.nowPageNum);
    }
}
