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
    /// ゲームシーンへ切り替えコルーチン
    /// </summary>
    public IEnumerator ChangeScene_Game()
    {
        //0.6後シーン切り替え
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("GameScene");
    }

    /// <summary>
    /// クレジットシーンへの切り替えコルーチン
    /// </summary>
    public IEnumerator ChangeScene_Credit()
    {
        //0.6後シーン切り替え
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("CreditScene");
    }

    /// <summary>
    /// チュートリアルシーンへの切り替えコルーチン
    /// </summary>
    public IEnumerator ChangeScene_Tutorial()
    {
        //0.6後シーン切り替え
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("TutorialScene");
    }
}
