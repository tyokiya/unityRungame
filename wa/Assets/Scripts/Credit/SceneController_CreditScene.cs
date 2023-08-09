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
    public void ChangeScene_Tittle()
    {
        SceneManager.LoadScene("TittleScene");
    }
}
