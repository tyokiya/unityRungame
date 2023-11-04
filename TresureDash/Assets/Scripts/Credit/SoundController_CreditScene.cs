using UnityEngine;

/// <summary>
/// クレジットシーンのサウンド管理クラス
/// </summary>
public class SoundController_CreditScene : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip   selectSound; // 決定音

    /// <summary>
    /// セレクトサウンドの再生
    /// </summary>
    public void PlySelectSound()
    {
        audioSource.PlayOneShot(selectSound);
    }
}
