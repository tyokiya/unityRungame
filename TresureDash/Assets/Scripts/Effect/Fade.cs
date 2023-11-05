using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// フェードアウト処理を行うクラス
/// </summary>
public class Fade : MonoBehaviour
{
    // フェードアウト、フェードイン時に使う画像素材
    [SerializeField] Image m_image = null; 

    void Reset()
    {
        m_image = GetComponent<Image>();
    }

    /// <summary>
    /// 時間経過でアルファ値を変更
    /// </summary>
    /// <param name="duration">フェード所要時間</param>
    /// <param name="is_reversing">フェードインフラグ</param>
    /// <returns></returns>
    IEnumerator ChangeAlphaValueFrom0To1OverTime(float duration, bool is_reversing = false)
    {
        if (!is_reversing) m_image.enabled = true;

        var elapsed_time = 0.0f;
        var color = m_image.color;

        while (elapsed_time < duration)
        {
            var elapsed_rate = Mathf.Min(elapsed_time / duration, 1.0f);
            color.a = is_reversing ? 1.0f - elapsed_rate : elapsed_rate;
            m_image.color = color;

            yield return null;
            elapsed_time += Time.deltaTime;
        }

        if (is_reversing) m_image.enabled = false;
    }

    /// <summary>
    /// フェードイン
    /// </summary>
    /// <param name="duration">フェード所要時間</param>
    public void FadeIn(float duration)
    {
        StartCoroutine(ChangeAlphaValueFrom0To1OverTime(duration, true));
    }

    /// <summary>
    /// フェードアウト
    /// </summary>
    /// <param name="duration">フェード所要時間</param>
    public void FadeOut(float duration)
    {
        StartCoroutine(ChangeAlphaValueFrom0To1OverTime(duration));
    }
}
