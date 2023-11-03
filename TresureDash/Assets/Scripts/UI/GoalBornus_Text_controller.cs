using UnityEngine;

/// <summary>
/// ボーナスUIのコントローラークラス
/// </summary>
public class GoalBornus_Text_controller : MonoBehaviour
{
    void Awake()
    {
        //描画しない状態に切り替える
        gameObject.SetActive(false);
    }

    /// <summary>
    /// ゴールボーナスUIを描画状態に切り替える
    /// </summary>
    public void GoalBornusUI_Active()
    {
        //描画切り替え
        gameObject.SetActive(true);
    }
}
