using UnityEngine;

/// <summary>
/// フレームレート制御クラス
/// </summary>
public class FrameCntroller : MonoBehaviour
{
    void Awake()
    {
        // フレームレート固定
        Application.targetFrameRate = 60;
    }
}
