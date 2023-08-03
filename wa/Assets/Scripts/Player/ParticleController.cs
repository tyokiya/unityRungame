using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    //インスペクター設定
    //プレイヤーのパーティクルオブジェクト
    [SerializeField] ParticleSystem particle_object;
    public void PlyCollisionParticle()
    {
        particle_object.Play();
    }
}
