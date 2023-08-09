using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

////////////////////////////////////
// タイトルシーンのシーンコントローラー
////////////////////////////////////

public class SceneController_TittleScene : MonoBehaviour
{
    /// <summary>
    /// ゲームシーンへ切り替え
    /// </summary>
    public void ChangeScene_Game()
    {
        SceneManager.LoadScene("GameScene");
    }

    /// <summary>
    /// クレジットシーンへの切り替え
    /// </summary>
    public void ChangeScene_Credit()
    {
        SceneManager.LoadScene("CreditScene");
    }

    /// <summary>
    /// チュートリアルシーンへの切り替え
    /// </summary>
    public void ChangeScene_Tutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}
