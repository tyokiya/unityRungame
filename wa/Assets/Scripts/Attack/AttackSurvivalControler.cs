using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// 攻撃の生存状態を管理するスクリプト
////////////////////////////////////

public class AttackSurvivalControler : MonoBehaviour
{
    
    //攻撃を管理するマネージャーを入れる
    GameObject attackManager;

    //プレイヤーの座標を入れる変数
    Vector3 plyPos;

    void Awake()
    {
        attackManager = GameObject.Find("AttackManager");
    }

    void Update()
    {
        //マネージャーからプレイヤーの座標を取得
        plyPos = attackManager.GetComponent<AttackManager>().GetPlayerPos();

        //攻撃オブジェクトがプレヤーから一定以上離れると
        //オブジェクトを破壊
        if(plyPos.z - 2.0f > transform.position.z)
        {
            Destroy(gameObject);
            //Debug.Log("攻撃オブジェクト破壊");
        }
    }
}
