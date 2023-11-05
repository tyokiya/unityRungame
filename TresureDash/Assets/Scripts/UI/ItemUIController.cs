using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// アイテムUIのコントローラーくらす
/// </summary>
public class ItemUIController : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] Text itemText; // アイテムスコアのテキスト

    /// <summary>
    /// 描画するスコアを更新する
    /// </summary>
    /// <param name="score">現在のプレイヤーのスコア</param>
    public void ItemTextUpdate(int score)
    {
        // int型をstring型に変換
        string stringText = score.ToString();
        // スコア更新
        itemText.text = stringText;
    }
}
