using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController_TutorialScene : MonoBehaviour
{
    /// <summary>
    /// タイトルシーンへ切り替えコルーチン
    /// </summary>
    public IEnumerator ChangeScene_Tittle()
    {
        //0.6後シーン切り替え
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("TittleScene");
    }
}
