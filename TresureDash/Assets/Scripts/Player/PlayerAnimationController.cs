using System.Collections;
using UnityEngine;

/// <summary>
/// プレイヤーのアニメーション管理クラス
/// </summary>
public class PlayerAnimationController : MonoBehaviour
{    
    // インスペクターから設定
    [SerializeField] Animator animator; // アニメーターを入れる変数

    // 定数
    const float WaitTime = 3f; // トリガー切り替え時の待機時間

    /// <summary>
    /// 3秒後トリガーを切り替えるコルーチン
    /// </summary>
    /// <returns></returns>
    public IEnumerator ChangeAnimaiton()
    {
        //3秒待機
        yield return new WaitForSeconds(WaitTime);
        //Debug.Log("トリガーコルーチン実行");
        //runアニメーションのトリガーに切り替える
        animator.SetTrigger("RunTrigger");
    }

    /// <summary>
    /// アニメーション更新
    /// </summary>
    /// <param name="flick">入力状態</param>
    /// <param name="state">プレイヤーの状態</param>
    /// <param name="collisionFlg">衝突フラグ</param>
    public void AnimationUpdate(ScreenInput.FlickDirection flick, Status.PlayerState state, bool collisionFlg)
    {
        // 入力を受けつけトリガーを切り替える
        if(flick == ScreenInput.FlickDirection.UP && state == Status.PlayerState.Run) animator.SetTrigger("JumpTrigger");

        // 衝突フラグが立ってる場合トリガーを切り替える
        if (collisionFlg) animator.SetTrigger("CollisionTrigger");
    }

    /// <summary>
    /// アニメーショントリガーをゴールに切り替える
    /// </summary>
    public void ChangeTrigger_Goal()
    {
        //アニメーショントリガーをゴールトリガーに切り替える
        animator.SetTrigger("GoalTrigger");
    }
}
