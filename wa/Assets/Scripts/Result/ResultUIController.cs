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

    GameObject sucore_object;

    //アイテムスコアテキストを入れるテキストオブジェクト
    [SerializeField] Text itemScore_text;
    //スコア獲得スコアを入れるテキストオブジェクト
    [SerializeField] Text runScore_text;
    //トータルスコアを入れるテキストオブジェクト
    [SerializeField] Text tortalScore_text;

    void Start()
    {
        //ゲームシーンのスコアオブジェクトからを受け取る
        sucore_object = GameObject.Find("ScoreController");
        //スコアを受け取る
        this.runScore = sucore_object.GetComponent<ScoreController>().ScoreGetter();
        //アイテム数を受け取る
        this.itemScore = sucore_object.GetComponent<ScoreController>().ItemNumGetter();
        //受け取った値からトータルスコアを計算
        this.tortalScore = this.runScore + (this.itemScore * 100);

        //int型をstring型に変換し、テキストに代入
        string s = this.runScore.ToString();
        this.runScore_text.text = s;

        s = this.itemScore.ToString();
        this.itemScore_text.text = s;

        s = this.tortalScore.ToString();
        this.tortalScore_text.text = s;
    }

}
