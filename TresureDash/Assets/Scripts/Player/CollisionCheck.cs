using UnityEngine;

/// <summary>
/// プレイヤーの衝突管理クラス
/// </summary>
public class CollisionCheck : MonoBehaviour
{
    [Tooltip("アイテムのタグ名定数")] 
    const string ItemTagName = "Item";

    [Tooltip("壁のタグ名定数")] 
    const string WallTagName = "wall";

    [Tooltip("ゴールのタグ名定数")] 
    const string GoalTagName = "GoalItem";

    [Tooltip("壁との衝突フラグ")] 
    bool collisionWallFlg = false;

    //インスペクターから設定
    [Tooltip("プレイヤーマネージャーのスクリプト")][SerializeField] 
    PlayerManager playerManager;

    [Tooltip("スコアマネージャー")][SerializeField]
    ScoreManager scoreManager;

    [Tooltip("UIマネージャー")][SerializeField] 
    UIManager UIManager;

    /// <summary>
    /// 衝突を感知しマネージャーに知らせる
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        //衝突したものがアイテムなのかを調べる
        if(other.tag == ItemTagName)
        {
            //Debug.Log("アイテムと衝突");
            //プレイヤーマネージャーに報告
            this.playerManager.ItemGetReport(other.transform.position);
            //スコアマネージャーに報告
            this.scoreManager.ItemGetReport();
            //獲得したアイテムオブジェクトを破壊
            Destroy(other.gameObject);
        }

        //衝突したものがゴールなのかを調べる
        if(other.tag == GoalTagName)
        {
            //プレイヤーマネージャーに報告
            this.playerManager.GoalReport();
            //スコアマネージャーに報告
            this.scoreManager.GoalItemGetReport();
            //UIマネージャーに報告
            this.UIManager.GoalReport();

            //獲得したゴールオブジェクトを破壊
            Destroy(other.gameObject);
        }
    }

    /// <summary>
    /// 衝突を検知しフラグを立てる
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision other)
    {
        //衝突したものが壁なのかを調べる
        if (other.gameObject.tag == WallTagName)
        {
            //衝突フラグを立てる
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
        return this.collisionWallFlg;
    }
}
