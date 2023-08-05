using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

////////////////////////////////////
// リザルトシーンのスコアUIのコントローラースクリプト
////////////////////////////////////

public class ResultUIController : MonoBehaviour
{
    //合計得点
    int tortalScore = 0;
    //ランスコア
    int runScore = 0;
    //アイテムスコア
    int itemScore = 0;

    //スコアテキストを入れる変数
    [SerializeField] Text item_text;

    void Start()
    {
        //ゲームシーンのスコアオブジェクトからを受け取る
        GameObject sucore_object = GameObject.Find("ScoreController");
        //スコアを受け取る
        this.runScore = sucore_object.GetComponent<ScoreController>().ScoreGetter();
        //アイテム数を受け取る
        this.itemScore = sucore_object.GetComponent <ScoreController>().ItemNumGetter();

        //int型をstring型に変換
        string s = runScore.ToString();
        item_text.text = s;
    }
}
