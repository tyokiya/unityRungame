using UnityEngine;

/// <summary>
/// クレジットシーンのサウンド管理クラス
/// </summary>
public class SoundController_CreditScene : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] AudioSource audioSource_object;
    [SerializeField] AudioClip   select_sound;

    /// <summary>
    /// セレクトサウンドの再生
    /// </summary>
    public void PlySelectSound()
    {
        this.audioSource_object.PlayOneShot(this.select_sound);
    }
}
