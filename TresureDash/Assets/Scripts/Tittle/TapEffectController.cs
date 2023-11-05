using UnityEngine;

/// <summary>
/// タイトルシーンのエフェクトのコントローラークラス
/// </summary>
public class TapEffectController : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] ParticleSystem tapEffectParticle; // タップエフェクトのパーティクル

    ParticleSystem[] particleArray = new ParticleSystem[ArrayMax]; // 生成したパーティクルを入れる配列
    int particleArray_cnt = 0;                                     // インデックスのカウンター

    // 定数
    const int ArrayMax           = 20;   // インデックスの最大数
    const float WaitDestroyTimer = 0.5f; // オブジェクト破壊までの待機時間

    void Update()
    {
        // 配列のカウント数が最大値になったら初期化
        if (particleArray_cnt == ArrayMax)
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
        // パーティクル生成
        particleArray[particleArray_cnt] = Instantiate(tapEffectParticle, pos, Quaternion.identity);
        // 時間経過後生成したパーティクルオブジェクトの削除
        Destroy(particleArray[particleArray_cnt].gameObject, WaitDestroyTimer);
        // カウント増加
        particleArray_cnt++;
    }
}
