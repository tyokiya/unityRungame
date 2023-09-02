using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

////////////////////////////////////
// クレジットシーンのシーンコントローラー
////////////////////////////////////

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
