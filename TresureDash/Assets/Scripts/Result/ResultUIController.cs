using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// リザルトシーンのスコアUIのコントローラークラス
/// </summary>
public class ResultUIController : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] TextMeshProUGUI itemScoreText;    // アイテムスコアを入れるテキストオブジェクト
    [SerializeField] TextMeshProUGUI runScoreText;     // スコアを入れるテキストオブジェクト
    [SerializeField] TextMeshProUGUI tortalScoreText; // トータルスコアを入れるテキストオブジェクト

    GameObject score_object; // 生成されたスコアオブジェクトを保持する

    // スコア
    int tortalScore = 0; // 合計得点
    int runScore    = 0; // ランスコア
    int itemScore   = 0; //アイテムスコア

    // 定数
    const int ScoreMagnification = 100; // スコア倍率の定数

    void Start()
    {
        // ゲームシーンのスコアオブジェクトからを受け取る
        score_object = GameObject.Find("Score_Controller");
        // スコアを受け取る
        runScore = score_object.GetComponent<ScoreController>().ScoreGetter();
        // アイテム数を受け取る
        itemScore = score_object.GetComponent<ScoreController>().ItemNumGetter();
        // 受け取った値からトータルスコアを計算
        tortalScore = runScore + (itemScore * ScoreMagnification);

        // int型をstring型に変換し、テキストに代入
        string stringText = runScore.ToString();
        runScoreText.text = stringText;

        stringText = itemScore.ToString();
        itemScoreText.text = stringText;

        stringText = tortalScore.ToString();
        tortalScoreText.text = stringText;
    }

}
