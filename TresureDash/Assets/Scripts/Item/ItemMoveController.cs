using UnityEngine;

/// <summary>
/// アイテムの動きを管理するクラス
/// </summary>
public class ItemMoveController : MonoBehaviour
{
    const float RotateSpeed_y = 10.0f; // アイテムのy軸回転スピード定数
    void Update()
    {
        // 一定の速度で回転
        transform.eulerAngles += new Vector3(0, RotateSpeed_y, 0);
    }
}
