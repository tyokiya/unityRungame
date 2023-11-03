using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトルシーンのシーンコントローラークラス
/// </summary>
public class SceneController_TittleScene : MonoBehaviour
{
    [Tooltip("シーン切り替え時の待機時間")]
    float waitTime = 0.6f;

    /// <summary>
    /// ゲームシーンへ切り替えコルーチン
    /// </summary>
    public IEnumerator ChangeScene_Game()
    {
        // 0.6後シーン切り替え
        yield return new WaitForSeconds(this.waitTime);
        SceneManager.LoadScene("GameScene");
    }

    /// <summary>
    /// クレジットシーンへの切り替えコルーチン
    /// </summary>
    public IEnumerator ChangeScene_Credit()
    {
        // 0.6後シーン切り替え
        yield return new WaitForSeconds(this.waitTime);
        SceneManager.LoadScene("CreditScene");
    }

    /// <summary>
    /// チュートリアルシーンへの切り替えコルーチン
    /// </summary>
    public IEnumerator ChangeScene_Tutorial()
    {
        // 0.6後シーン切り替え
        yield return new WaitForSeconds(this.waitTime);
        SceneManager.LoadScene("TutorialScene");
    }
}
