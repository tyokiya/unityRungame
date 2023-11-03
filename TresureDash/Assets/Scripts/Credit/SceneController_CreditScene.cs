using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// クレジットシーンのシーン管理クラス
/// </summary>
public class SceneController_CreditScene : MonoBehaviour
{
    // シーン切り替えまでの待機時間
    const float WaitTimeSceneChange = 0.6f;

    /// <summary>
    /// タイトルシーンへ切り替え
    /// </summary>
    public IEnumerator ChangeScene_Tittle()
    {
        // 0.6後シーン切り替え
        yield return new WaitForSeconds(WaitTimeSceneChange);
        SceneManager.LoadScene("TitleScene");
    }
}
