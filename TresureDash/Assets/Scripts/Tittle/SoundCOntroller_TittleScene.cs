using UnityEngine;

/// <summary>
/// タイトルシーンのサウンドコントローラークラス
/// </summary>
public class SoundCOntroller_TittleScene : MonoBehaviour
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
