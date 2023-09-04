using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

////////////////////////////////////
// タイトルシーンの入力を受け取るスクリプト
////////////////////////////////////

public class ScreenInput_TittleScene : MonoBehaviour
{
    //インスペクターから設定
    [Tooltip("エフェクト表示用カメラオブジェクト")][SerializeField] 
    Camera effectCamera_objet;

    [Tooltip("タップワールド座標")]
    Vector3 tapPos;

    bool tapFlg = false;

    void Update()
    {
        //入力があった場合座標設定
        if (Input.GetMouseButtonDown(0))
        {
            // マウスのワールド座標取得
            this.tapPos = effectCamera_objet.ScreenToWorldPoint(Input.mousePosition + effectCamera_objet.transform.forward * 10);
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
