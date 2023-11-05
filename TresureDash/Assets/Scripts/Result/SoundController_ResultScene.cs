using UnityEngine;

/// <summary>
/// リザルトシーンのサウンドコントローラー
/// </summary>
public class SoundController_ResultScene : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] AudioSource audioSource; // オーディオソース
    [SerializeField] AudioClip   selectSound; // 決定音

    /// <summary>
    /// セレクトサウンドの再生
    /// </summary>
    public void PlySelectSound()
    {
        audioSource.PlayOneShot(selectSound);
    }
}
