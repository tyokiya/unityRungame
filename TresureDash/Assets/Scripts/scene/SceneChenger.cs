﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーンの切り替えクラス
/// </summary>
public class SceneChenger : MonoBehaviour
{
    /// <summary>
    /// リザルトシーンに切り替える
    /// </summary>
    /// <param name="stand_time">シーン切り替えまでの待機時間</param>
    public IEnumerator ChangeResultScene(float stand_time)
    {
        // 引数分待機後シーン切り替え
        yield return new WaitForSeconds(stand_time);
        SceneManager.LoadScene("ResultScene");
    }
}
