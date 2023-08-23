using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    //インスペクタからー設定
    [Tooltip("プレイヤーの衝突パーティクルオブジェクト")][SerializeField]
    ParticleSystem collidionParticle_object;

    [Tooltip("プレイヤーのアイテムゲットパーティクルオブジェクト")][SerializeField]
    ParticleSystem itemGetParticle_object;

    [Tooltip("生成したパーティクルを入れる配列")]
    ParticleSystem[] particleArray = new ParticleSystem[20];
    int particleArray_cnt = 0;
    
    const int arrayMax_const = 20;

    void Update()
    {
        //配列のカウント数が最大値になったら初期化
        if (particleArray_cnt == arrayMax_const)
        {
            particleArray_cnt = 0;
        }
    }

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
    /// <param name="itemPos">アイテムを獲得した座標</param>
    public void PlyItemGetParticle(Vector3 itemplayerPos)
    {
        //this.itemGetParticle_object.Play();
        //パーティクル生成
        this.particleArray[this.particleArray_cnt] = Instantiate(itemGetParticle_object);
        //座標設定
        this.particleArray[this.particleArray_cnt].transform.position = itemplayerPos;
        //パーティクル再生
        this.particleArray[this.particleArray_cnt].Play();
        //時間経過後生成したパーティクルオブジェクトの削除
        Destroy(this.particleArray[this.particleArray_cnt].gameObject,1.0f);
        //カウント増加
        this.particleArray_cnt++;
    }

}
