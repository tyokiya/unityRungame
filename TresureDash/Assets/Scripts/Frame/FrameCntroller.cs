using UnityEngine;

/// <summary>
/// フレームレート制御クラス
/// </summary>
public class FrameCntroller : MonoBehaviour
{
    const int MaxFrameRate = 60;
    void Awake()
    {
        // フレームレート固定
        Application.targetFrameRate = MaxFrameRate;
    }
}
