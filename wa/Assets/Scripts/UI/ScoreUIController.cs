using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIController : MonoBehaviour
{
    [Tooltip("スコアオブジェクト")][SerializeField] 
    GameObject score_object;

    [Tooltip("スコアテキスト")][SerializeField]
    Text score_text;

    /// <summary>
    /// 描画するスコアを更新する
    /// </summary>
    /// <param name="score">現在のプレイヤーのスコア</param>
    public void ScoreTextUpdate(int score)
    {
        //int型をstring型に変換
        string s = score.ToString();
        //スコア更新
        this.score_text.text = s;
    }
}
