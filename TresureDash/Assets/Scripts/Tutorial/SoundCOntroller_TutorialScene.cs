using UnityEngine;

/// <summary>
/// チュートリアルシーンのサウンドコントローラークラス
/// </summary>
public class SoundCOntroller_TutorialScene : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] AudioSource audioSource; // オーディオソース
    [SerializeField] AudioClip   selectSound; // 決定音
    [SerializeField] AudioClip   pageSound;   // ページをめくる音

    /// <summary>
    /// セレクトサウンドの再生
    /// </summary>
    public void PlySelectSound()
    {
        audioSource.PlayOneShot(selectSound);
    }

    /// <summary>
    /// ページをめくる音の再生
    /// </summary>
    public void PlyPageSound()
    {
        audioSource.PlayOneShot(pageSound);
    }
}
