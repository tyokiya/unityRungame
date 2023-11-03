using UnityEngine;

/// <summary>
/// プレイヤーのパーティクル管理クラス
/// </summary>
public class ParticleController : MonoBehaviour
{
    //インスペクタからー設定
    [Tooltip("プレイヤーの衝突時パーティクル")][SerializeField]
    ParticleSystem collision_particle;

    [Tooltip("プレイヤーのアイテムゲットパーティクルオブジェクト")][SerializeField]
    ParticleSystem itemGet_particle;

    [Tooltip("生成したパーティクルを入れる配列")]
    ParticleSystem[] particleArray = new ParticleSystem[20];

    int particleArray_cnt =           0;
    const int ArrayMax =       20;
    const float WaitDestroyTimer = 1.0f;

    void Update()
    {
        //配列のカウント数が最大値になったら初期化
        if (particleArray_cnt == ArrayMax)
        {
            particleArray_cnt = 0;
        }
    }

    /// <summary>
    /// 衝突時のパーティクル再生
    /// </summary>
    public void PlyCollisionParticle()
    {
        collision_particle.Play();
    }

    /// <summary>
    /// アイテムゲット時のパーティクル再生
    /// </summary>
    /// <param name="itemPos">アイテムを獲得した座標</param>
    public void PlyItemGetParticle(Vector3 itemplayerPos)
    {
        //パーティクル生成
        this.particleArray[this.particleArray_cnt] = Instantiate(itemGet_particle);
        //座標設定
        this.particleArray[this.particleArray_cnt].transform.position = itemplayerPos;
        //パーティクル再生
        this.particleArray[this.particleArray_cnt].Play();
        //時間経過後生成したパーティクルオブジェクトの削除
        Destroy(this.particleArray[this.particleArray_cnt].gameObject, WaitDestroyTimer);
        //カウント増加
        this.particleArray_cnt++;
    }

}
