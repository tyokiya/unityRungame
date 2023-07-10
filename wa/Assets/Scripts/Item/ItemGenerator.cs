using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //�A�C�e���v���t�@�u������ϐ�
    public GameObject itemPrefab;

    //�A�C�e���������̃v���C���[�Ƃ̋���
    [SerializeField] float itemDistance = 30.0f;

    public void CreateItem(Vector3 plyPos)
    {
        Debug.Log("�A�C�e������");
        GameObject item = Instantiate(this.itemPrefab);
        //���W�ݒ�
        int dice = Random.Range(-1, 2);
        item.transform.position = new Vector3(0.8f * dice, 0, plyPos.z + this.itemDistance);
    }
}
