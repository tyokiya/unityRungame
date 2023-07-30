using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
////////////////////////////////////
// シーンのコントローラースクリプト
////////////////////////////////////
public class SceneController : MonoBehaviour
{
    //シーン切り替えの用のデリゲート定義
    public delegate IEnumerator changeScene_delegate();

    /// <summary>
    /// リザルトシーンに切り替える
    /// </summary>
    public IEnumerator ChangeResultScene()
    {
        //1秒待機後シーン切り替え
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("ResultScene");
    }
}
