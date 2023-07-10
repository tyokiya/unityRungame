using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //アイテムプレファブを入れる変数
    public GameObject itemPrefab;

    //アイテム生成時のプレイヤーとの距離
    [SerializeField] float itemDistance = 30.0f;

    public void CreateItem(Vector3 plyPos)
    {
        Debug.Log("アイテム生成");
        GameObject item = Instantiate(this.itemPrefab);
        //座標設定
        int dice = Random.Range(-1, 2);
        item.transform.position = new Vector3(0.8f * dice, 0, plyPos.z + this.itemDistance);
    }
}
