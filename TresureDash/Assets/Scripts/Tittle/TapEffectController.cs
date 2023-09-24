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

    [Tooltip("生成したパーティクルを入れる配列")]
    ParticleSystem[] particleArray = new ParticleSystem[20];
    int particleArray_cnt = 0;

    const int arrayMax_const           = 20;
    const float waitDestroyTimer_const = 0.5f;

    void Update()
    {
        //配列のカウント数が最大値になったら初期化
        if (particleArray_cnt == arrayMax_const)
        {
            particleArray_cnt = 0;
        }
    }

    /// <summary>
    /// タップエフェクトの表示
    /// </summary>
    /// <param name="pos">エフェクトの生成座標</param>
    public void PlyTapEffect(Vector3 pos)
    {
        //パーティクル生成
        this.particleArray[this.particleArray_cnt] = Instantiate(this.tapEffect_particle);
        //座標設定
        this.particleArray[this.particleArray_cnt].transform.position = pos;
        //パーティクル再生
        this.particleArray[this.particleArray_cnt].Play();
        //時間経過後生成したパーティクルオブジェクトの削除
        Destroy(this.particleArray[this.particleArray_cnt].gameObject, waitDestroyTimer_const);
        //カウント増加
        this.particleArray_cnt++;
    }
}
