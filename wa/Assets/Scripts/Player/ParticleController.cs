using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    //インスペクター設定
    //プレイヤーのパーティクルオブジェクト
    [SerializeField] ParticleSystem collidionParticle_object;
    //プレイヤーのアイテムゲットパーティクルオブジェクト
    [SerializeField] ParticleSystem itemGetParticle_object;

    /// <summary>
    /// 衝突時のパーティクル再生
    /// </summary>
    public void PlyCollisionParticle()
    {
        collidionParticle_object.Play();
    }

    /// <summary>
    /// アイテムゲット時のパーティクル再生
    /// </summary>
    public void PlyItemGetParticle()
    {
        this.itemGetParticle_object.Play();
    }
}
