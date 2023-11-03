using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// クレジットシーンのシーン管理クラス
/// </summary>
public class SceneController_CreditScene : MonoBehaviour
{
    /// <summary>
    /// タイトルシーンへ切り替え
    /// </summary>
    public IEnumerator ChangeScene_Tittle()
    {
        //0.6後シーン切り替え
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("TitleScene");
    }
}
