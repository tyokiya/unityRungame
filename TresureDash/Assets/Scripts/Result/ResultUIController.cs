﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

////////////////////////////////////
// リザルトシーンのスコアUIのコントローラースクリプト
////////////////////////////////////

public class ResultUIController : MonoBehaviour
{
    [Tooltip("合計得点")]
    int tortalScore = 0;
    [Tooltip("ランスコア")]
    int runScore = 0;
    [Tooltip("アイテムスコア")]
    int itemScore = 0;

    [Tooltip("スコアオブジェクト")]
    GameObject score_object;
    
    [Tooltip("アイテムスコアを入れるテキストオブジェクト")][SerializeField]
    Text itemScore_text;

    [Tooltip("スコアを入れるテキストオブジェクト")][SerializeField] 
    Text runScore_text;
    
    [Tooltip("トータルスコアを入れるテキストオブジェクト")][SerializeField] 
    Text tortalScore_text;

    void Start()
    {
        //ゲームシーンのスコアオブジェクトからを受け取る
        score_object = GameObject.Find("Score_Controller");
        //スコアを受け取る
        this.runScore = score_object.GetComponent<ScoreController>().ScoreGetter();
        //アイテム数を受け取る
        this.itemScore = score_object.GetComponent<ScoreController>().ItemNumGetter();
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