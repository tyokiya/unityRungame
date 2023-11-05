using UnityEngine;

/// <summary>
/// プレイヤーの衝突管理クラス
/// </summary>
public class CollisionCheck : MonoBehaviour
{    
    //インスペクターから設定
    [SerializeField] PlayerManager playerManager; // プレイヤーマネージャークラス
    [SerializeField] ScoreManager  scoreManager;  // スコアマネージャークラス
    [SerializeField] UIManager     UIManager;     // UIマネージャークラス

    // タグ名定数
    const string ItemTagName = "Item";     // アイテムのタグ名定数
    const string WallTagName = "wall"; 　　// 壁のタグ名定数
    const string GoalTagName = "GoalItem"; // ゴールのタグ名定数

    bool collisionWallFlg = false; //壁との衝突フラグ

    /// <summary>
    /// 衝突を感知しマネージャーに知らせる
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        // 衝突したものがアイテムなのかを調べる
        if(other.tag == ItemTagName)
        {
            //Debug.Log("アイテムと衝突");
            // プレイヤーマネージャーに報告
            playerManager.ItemGetReport(other.transform.position);
            // スコアマネージャーに報告
            scoreManager.ItemGetReport();
            // 獲得したアイテムオブジェクトを破壊
            Destroy(other.gameObject);
        }

        // 衝突したものがゴールなのかを調べる
        if(other.tag == GoalTagName)
        {
            // プレイヤーマネージャーに報告
            playerManager.GoalReport();
            // スコアマネージャーに報告
            scoreManager.GoalItemGetReport();
            // UIマネージャーに報告
            UIManager.GoalReport();

            // 獲得したゴールオブジェクトを破壊
            Destroy(other.gameObject);
        }
    }

    /// <summary>
    /// 衝突を検知しフラグを立てる
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision other)
    {
        // 衝突したものが壁なのかを調べる
        if (other.gameObject.tag == WallTagName)
        {
            // 衝突フラグを立てる
            collisionWallFlg = true;
            //Debug.Log("衝突");
        }
    }

    /// <summary>
    /// 衝突フラグを返す
    /// </summary>
    /// <returns>プレイヤーの壁との衝突フラグ</returns>
    public bool GetCollisionFlg()
    {
        return collisionWallFlg;
    }
}
