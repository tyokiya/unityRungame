using UnityEngine;

/// <summary>
/// タイトルシーンの入力を受け取るスクリプト
/// </summary>
public class ScreenInput_TittleScene : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] Camera UICamera; // エフェクト表示用カメラオブジェクト

    // タップしたワールド座標保持
    Vector3 tapPos;
    
    // タップフラグ
    bool tapFlg = false;

    void Update()
    {
        // 入力があった場合座標設定
        if (Input.GetMouseButtonDown(0))
        {
            // タップしたワールド座標取得しエフェクトの生成座標設定
            tapPos = UICamera.ScreenToWorldPoint(Input.mousePosition + UICamera.transform.forward);
            // フラグを立てる
            tapFlg = true;
        }
        else
        {
            // フラグを下ろす
            tapFlg = false;
        }
    }

    /// <summary>
    /// タップフラグのゲッター
    /// </summary>
    /// <returns>タップフラグ</returns>
    public bool TapFlgGetter()
    {
        return tapFlg;
    }

    /// <summary>
    /// タップ座標のゲッター(ワールド座標)
    /// </summary>
    /// <returns>タップ座標</returns>
    public Vector3 TapPosGetter()
    {
        return tapPos;
    }
}
