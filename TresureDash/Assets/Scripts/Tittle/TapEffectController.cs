using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

////////////////////////////////////
// タイトルシーンのエフェクトのコントローラースクリプト
////////////////////////////////////

public class TapEffectController : MonoBehaviour
{
    //インスペクターから設定
    [Tooltip("タップエフェクトのパーティクル")][SerializeField]
    ParticleSystem tapEffect_particle;

    /// <summary>
    /// タップエフェクトの表示
    /// </summary>
    /// <param name="pos">エフェクトの生成座標</param>
    public void PlyTapEffect(Vector3 pos)
    {
        //座標設定
        tapEffect_particle.transform.position = pos;
        //エフェクト生成
        tapEffect_particle.Emit(1);
    }
}
