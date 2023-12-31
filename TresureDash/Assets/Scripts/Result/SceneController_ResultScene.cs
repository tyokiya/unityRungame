﻿using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// リザルトシーンのシーンコントローラークラス
/// </summary>
public class SceneController_ResultScene : MonoBehaviour
{
    /// <summary>
    /// ゲームシーンへ切り替え
    /// </summary>
    public void ChangeScene_Game()
    {
        SceneManager.LoadScene("GameScene");
    }

    /// <summary>
    /// タイトルシーンへの切り替え
    /// </summary>
    public void ChangeScene_Tittle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
