using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIController : MonoBehaviour
{
    //スコアオブジェクトを入れる変数
    public GameObject score_object;

    //スコアテキストを入れる変数
    Text score_text;

    void Awake()
    {
        //テキストコンポーネントを取得
        score_text = score_object.GetComponent<Text>();
    }

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
