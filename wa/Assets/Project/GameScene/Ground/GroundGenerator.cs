using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// 地面を生成するスクリプト
////////////////////////////////////

public class GroundGenerator : MonoBehaviour
{
    //地面のprefabを入れる変数
    public GameObject groundPrefab;
    //生成間隔を測るタイマー
    [SerializeField] private float span = 1.5f;
    float delta = 0;
    //生成した地面の枚数カウンター
    int GroundCnt = 0;

    void Start()
    {
        //地面10枚分生成
        for(int i = 0; i < 10; i++)
        {
            //カウント増加
            this.GroundCnt++;

            //生成メソッド呼び出し
            CreateGround(GroundCnt);
        }
    }

    void Update()
    {
        //deltaカウント増加
        this.delta += Time.deltaTime;
        //3秒ごとに地面生成
        if(this.delta > this.span)
        {
            //delta初期化
            this.delta = 0;

            //カウント増加
            this.GroundCnt++;

            //生成メソッド呼び出し
            CreateGround(GroundCnt);
        }
    }

    /// <summary>
    /// 地面を生成するメソッド
    /// </summary>
    /// <param name="groundCnt">生成した地面の枚数カウンター</param>
    void CreateGround(int groundCnt)
    {
        //インスタンス生成
        GameObject ground = Instantiate(groundPrefab);
        ground.transform.position = new Vector3(0, 0, groundCnt * 10);
    }
}
