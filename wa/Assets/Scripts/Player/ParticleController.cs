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
    
    //生成したパーティクルを入れる配列
    ParticleSystem[] particleArray = new ParticleSystem[20];
    //配列数のカウント
    int arrayCnt = 0;
    //配列のマックス数
    const int arrayMax = 20;

    void Update()
    {
        //配列のカウント数が最大値になったら初期化
        if (arrayCnt == arrayMax)
        {
            arrayCnt = 0;
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
        this.particleArray[this.arrayCnt] = Instantiate(itemGetParticle_object);
        //座標設定
        this.particleArray[this.arrayCnt].transform.position = itemplayerPos;
        //パーティクル再生
        this.particleArray[this.arrayCnt].Play();
        //時間経過後生成したパーティクルオブジェクトの削除
        Destroy(this.particleArray[this.arrayCnt].gameObject,1.0f);
        //カウント増加
        this.arrayCnt++;
    }

}
