using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

////////////////////////////////////
// カウントダウンテキストのコントローラースクリプト
////////////////////////////////////

public class CountDownController : MonoBehaviour
{
    [Tooltip("カウントダウンのテキストオブジェクト")][SerializeField]
    Text countDown_text;

    [Tooltip("カウントダウンの現在の値")]
    int nowCountDown_number = 3;

    void Awake()
    {
        //カウントダウンコルーチンのスタート
        StartCoroutine(StartCountDown());
    }

    public IEnumerator StartCountDown()
    {
        //コルーチンスタートから1秒待機後
        yield return new WaitForSeconds(1f);
        //カウント減少
        this.nowCountDown_number--;
        //string型に変換
        string s = this.nowCountDown_number.ToString();
        //カウントダウンのテキスト変更
        this.countDown_text.text = s;

        //コルーチンスタートから2秒待機後
        yield return new WaitForSeconds(1f);
        //カウント減少
        this.nowCountDown_number--;
        //string型に変換
        s = this.nowCountDown_number.ToString();
        //カウントダウンのテキスト変更
        this.countDown_text.text = s;

        //コルーチンスタートから3秒待機後
        yield return new WaitForSeconds(1f);
        //カウントダウンテキストオブジェクトと
        //このコントローラーオブジェクトの破壊
        Destroy(gameObject);
        Destroy(this.countDown_text.gameObject);
    }
}
