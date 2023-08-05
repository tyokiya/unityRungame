using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

////////////////////////////////////
// リザルトシーンでのシーンコントローラー
////////////////////////////////////

public class SceneController_ResultScene : MonoBehaviour
{

    /// <summary>
    /// ゲームシーンへ切り替え
    /// </summary>
    public void ChangeScene_Game()
    {
        SceneManager.LoadScene("GameScene");
    }
}
