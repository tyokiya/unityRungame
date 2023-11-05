using UnityEngine;

/// <summary>
/// プレイヤーのパーティクル管理クラス
/// </summary>
public class ParticleController : MonoBehaviour
{
    // インスペクタからー設定
    [SerializeField] ParticleSystem collision_particle; // プレイヤーの衝突時パーティクル
    [SerializeField] ParticleSystem itemGet_particle;   // プレイヤーのアイテムゲットパーティクルオブジェクト

    ParticleSystem[] particleArray = new ParticleSystem[20]; // 生成したパーティクルを入れる配列
    int particleArray_cnt = 0;                               // パーティクルをいれてる配列のインデックス数

    // 定数
    const int   ArrayMax = 20;           // インデックスのマックス数
    const float WaitDestroyTimer = 1.0f; // オブジェクト破壊までの待機時間

    void Update()
    {
        // 配列のカウント数が最大値になったら初期化
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
        // パーティクル生成
        particleArray[particleArray_cnt] = Instantiate(itemGet_particle);
        // 座標設定
        particleArray[particleArray_cnt].transform.position = itemplayerPos;
        // パーティクル再生
        particleArray[particleArray_cnt].Play();
        // 時間経過後生成したパーティクルオブジェクトの削除
        Destroy(particleArray[particleArray_cnt].gameObject, WaitDestroyTimer);
        // カウント増加
        particleArray_cnt++;
    }

}
