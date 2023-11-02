using UnityEngine;

////////////////////////////////////
// タイトルシーンの入力を受け取るスクリプト
////////////////////////////////////

public class ScreenInput_TittleScene : MonoBehaviour
{
    //インスペクターから設定
    [Tooltip("エフェクト表示用カメラオブジェクト")][SerializeField] 
    Camera effectCamera_objet;

    [Tooltip("タップしたワールド座標")]
    Vector3 tapPos;

    bool tapFlg = false;

    void Update()
    {
        //入力があった場合座標設定
        if (Input.GetMouseButtonDown(0))
        {
            // タップしたワールド座標取得し
            //エフェクトの生成座標設定
            this.tapPos = effectCamera_objet.ScreenToWorldPoint(Input.mousePosition + effectCamera_objet.transform.forward);

            //フラグを立てる
            this.tapFlg = true;
        }
        else
        {
            //フラグを下ろす
            this.tapFlg = false;
        }
    }

    /// <summary>
    /// タップフラグのゲッター
    /// </summary>
    /// <returns>タップフラグ</returns>
    public bool TapFlgGetter()
    {
        return this.tapFlg;
    }

    /// <summary>
    /// タップ座標のゲッター(ワールド座標)
    /// </summary>
    /// <returns>タップ座標</returns>
    public Vector3 TapPosGetter()
    {
        return this.tapPos;
    }
}
