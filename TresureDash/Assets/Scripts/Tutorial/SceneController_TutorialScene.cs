using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// チュートリアルシーンのシーンコントローラークラス
/// </summary>
public class SceneController_TutorialScene : MonoBehaviour
{
    // 定数
    const float waitTime = 0.6f; // シーン切り替え時の待機時間 

    /// <summary>
    /// タイトルシーンへ切り替えコルーチン
    /// </summary>
    public IEnumerator ChangeScene_Tittle()
    {
        // 0.6後シーン切り替え
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("TitleScene");
    }
}
