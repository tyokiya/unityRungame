using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// 攻撃を生成するスクリプト
////////////////////////////////////

public class AttackGenerator : MonoBehaviour
{
    //攻撃のプレファブを入れる変数
    public GameObject KnifePrefab;
    public GameObject makibishiPrefab;

    //一度に生成する攻撃の個数
    [SerializeField] int knifeNum = 1;

    //ナイフ生成時のプレイヤーとの距離
    [SerializeField] float knifeDistance = 30.0f;
    //まきびし生成時のプレイヤーとの距離
    [SerializeField] float makibishiDistance = 20.0f;

    /// <summary>
    /// ナイフ攻撃を生成
    /// </summary>
    /// <param name="plyPos">プレイヤーの座標</param>
    public void CreateKnife(Vector3 plyPos)
    {
        //現在の生成数を元に攻撃を生成
        if (this.knifeNum == 1)
        {
            GameObject knife = Instantiate(this.KnifePrefab);
            //座標設定
            int dice = Random.Range(-1, 2);
            knife.transform.position = new Vector3(0.8f * dice, 0, plyPos.z + this.knifeDistance);
        }
        else if (this.knifeNum == 2)
        {
            GameObject knife = Instantiate(this.KnifePrefab);
            GameObject knife2 = Instantiate(this.KnifePrefab);
            //座標設定
            int dice = Random.Range(-1, 2);
            int dice2 = dice;
            //別の値ができるまでループ
            while(dice2 == dice)
            {
                dice2 = Random.Range(-1, 2);
            }
            knife2.transform.position = new Vector3(0.8f * dice, 0, plyPos.z + this.knifeDistance);

        }
    }

    /// <summary>
    /// まきびしを生成
    /// </summary>
    /// <param name="plyPos">プレイヤーの座標</param>
    public void CreateMakibisi(Vector3 plyPos)
    {
        //攻撃の生成
        GameObject makibishi = Instantiate(this.makibishiPrefab);
        //座標設定
        makibishi.transform.position = new Vector3(plyPos.x, 0, plyPos.z + this.makibishiDistance);
    }

    /// <summary>
    /// ナイフの生成数増加
    /// </summary>
    /// <param name="changeNum">変える生成数</param>
    public void SetKnifeNum(int changeNum)
    {
        this.knifeNum = changeNum;
    }
}
