using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

////////////////////////////////////
// アイテムUIのコントローラースクリプト
////////////////////////////////////

public class ItemUIController : MonoBehaviour
{
    //スコアオブジェクトを入れる変数
    [SerializeField] GameObject item_object;

    //スコアテキストを入れる変数
    [SerializeField] Text item_text;

    /// <summary>
    /// 描画するスコアを更新する
    /// </summary>
    /// <param name="score">現在のプレイヤーのスコア</param>
    public void ItemTextUpdate(int score)
    {
        //int型をstring型に変換
        string s = score.ToString();
        //スコア更新
        this.item_text.text = s;
    }
}
