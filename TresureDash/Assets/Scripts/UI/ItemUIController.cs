using UnityEngine;
using UnityEngine.UI;

////////////////////////////////////
// アイテムUIのコントローラースクリプト
////////////////////////////////////

public class ItemUIController : MonoBehaviour
{
    [Tooltip("アイテムスコアオブジェクト")][SerializeField]
    GameObject item_object;

    [Tooltip("アイテムスコアのテキスト")][SerializeField]
    Text item_text;

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
