using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// カウントダウンUIのコントローラースクリプト
/// </summary>
public class CountDownController : MonoBehaviour
{
    //カウントダウンのテキストオブジェクト
    [SerializeField] Text countDown_text;
    //残りカウントを表示するイメージオブジェクト
    [SerializeField] Image countDownImg;

    // 数える時間の定数
    const float CountTimeNum = 1.0f;
    // 合計の数える時間
    const int TortalCountTime = 3;
    // fillAmountの初期値定数
    const float InitialFillAmount = 1.0f;

    void Awake()
    {
        //カウントダウンコルーチンのスタート
        StartCoroutine(StartCountDown());
    }

    /// <summary>
    /// 三秒のカウントダウン
    /// </summary>
    /// <returns></returns>
    public IEnumerator StartCountDown()
    {
        //時間をテキストにセット
        int nowCountDownTime = 3;
        countDown_text.text = nowCountDownTime.ToString();

        for (int i = 0; i < TortalCountTime; i++)
        {
            // 1秒のカウントダウン呼び出し
            yield return CountDown1Second(nowCountDownTime);
            // カウント数更新
            nowCountDownTime--;
        }

        //カウントダウンテキストオブジェクトと
        //このコントローラーオブジェクトの破壊
        Destroy(gameObject);
        Destroy(this.countDown_text.gameObject);
        Destroy(this.countDownImg.gameObject);
    }

    /// <summary>
    /// 1秒のカウントダウンを行う
    /// </summary>
    /// <param name="nowCountDownTime">現在のカウントダウン時間</param>
    IEnumerator CountDown1Second(int nowCountDownTime)
    {
        // ループ内での時間経過を保持する
        float time = 0;

        // 1秒ループ
        while (time < 1.0f)
        {
            countDownImg.fillAmount -= Time.deltaTime; // 差分をfillAmountに減算
            time += Time.deltaTime;
            yield return null;
        }
        // 一秒ごとにカウントダウンのテキスト更新
        //カウント減少
        nowCountDownTime--;
        //string型に変換
        string s = nowCountDownTime.ToString();
        //カウントダウンのテキスト変更
        this.countDown_text.text = s;
        countDownImg.fillAmount = InitialFillAmount; // fillAmount初期化
    }
}
