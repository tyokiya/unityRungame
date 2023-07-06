using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //親オブジェクト
    GameObject ParentObject;

    //アニメーターを入れる変数
    Animator animator;

    void Start()
    {
        //親オブジェクトを取得
        ParentObject = GameObject.Find("Player");
        //コンポーネント取得
        this.animator = ParentObject.GetComponent<Animator>();
    }

    /// <summary>
    /// 3秒後トリガーを切り替えるコルーチン
    /// </summary>
    /// <returns></returns>
    public IEnumerator ChangeAnimaiton()
    {
        //3秒待機
        yield return new WaitForSeconds(3f);
        //Debug.Log("トリガーコルーチン実行");
        //runアニメーションのトリガーに切り替える
        this.animator.SetTrigger("RunTrigger");
    }

    /// <summary>
    /// アニメーション更新
    /// </summary>
    /// <param name="flick">入力状態</param>
    /// <param name="situation">プレイヤーの状態</param>
    public void AnimationUpdate(ScreenInput.FlickDirection flick, Status.situation situation)
    {
        //入力を受けつけトリガーを切り替える
        if(flick == ScreenInput.FlickDirection.UP && situation == Status.situation.run) this.animator.SetTrigger("JumpTrigger");
    }
}
