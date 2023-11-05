using UnityEngine;

/// <summary>
/// プレイヤーのサウンドを管理するコントローラークラス
/// </summary>
public class SoundController : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] AudioSource audioSource; // オーディオソースオブジェクト

    // 再生音
    [SerializeField] AudioClip foot_sound;      // 足音
    [SerializeField] AudioClip fall_sound;      // 落下音
    [SerializeField] AudioClip jump_sound;      // ジャンプ音
    [SerializeField] AudioClip collision_sound; // 衝突音
    [SerializeField] AudioClip getItem_sound;   // アイテム獲得音
    [SerializeField] AudioClip goal_sound;      // ゴール音

    // 定数
    const float WalkSound_span = 0.5f; // 足音(歩き)再生のスパン定数
    const float RunSound_span = 0.3f;  // 足音(走り)再生のスパン

    float foot_sound_delta = 0; // デルタタイムを保持する

    // サウンド再生時のデリゲート
    public delegate void PlyPlayerSound();

    /// <summary>
    /// 現在のプレイヤーの状態に応じて移動音再生
    /// </summary>
    /// <param name="state">現在のプレイヤーの状態</param>
    public void PlyWalkSound(Status.PlayerState state)
    {
        // 現在の状態を見てサウンド再生
        if(state == Status.PlayerState.Walk && foot_sound_delta > WalkSound_span)
        {
            // 足音再生
            audioSource.PlayOneShot(foot_sound);
            // デルタ初期化
            foot_sound_delta = 0;
        }
        else if(state == Status.PlayerState.Run && foot_sound_delta > RunSound_span)
        {
            // 足音再生
            audioSource.PlayOneShot(foot_sound);
            // デルタ初期化
            foot_sound_delta = 0;
        }
        // デルタ増加
        foot_sound_delta += Time.deltaTime;
    }

    /// <summary>
    /// 落下音再生
    /// </summary>
    public void PlyFallSound()
    {
        audioSource.PlayOneShot(fall_sound);
    }

    /// <summary>
    /// 衝突音再生
    /// </summary>
    public void PlyCollisionSound()
    {
        audioSource.PlayOneShot(collision_sound);
    }

    /// <summary>
    /// ジャンプ音再生
    /// </summary>
    public void PlyJumpSound()
    {
        audioSource.PlayOneShot(jump_sound);
    }

    /// <summary>
    /// アイテム取得音再生
    /// </summary>
    public void PlyGetItemSound()
    {
        audioSource.PlayOneShot(getItem_sound);
    }

    /// <summary>
    /// ゴール音再生
    /// </summary>
    public void PlyGoalSound()
    {
        audioSource.PlayOneShot(goal_sound);
    }
}
