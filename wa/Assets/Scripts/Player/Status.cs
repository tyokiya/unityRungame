using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;

////////////////////////////////////
// プレイヤーのステータスを管理するスクリプト
////////////////////////////////////

public class Status : MonoBehaviour
{
    //インスペクターから設定
    //親オブジェクトのトランスフォームを入れる変数
    [SerializeField] Transform parent_transform;
    //プレイヤーの落下判定のy座標ボーダー
    float playerFallBorder_y = -0.5f;
    //タイマー
    float delta = 0;
    //連続で回転処理させないためのスパン
    float rotationSpan = 1.0f;

    //プレイヤーの状態
    public enum PlayerSituation
    { 
        walk,
        run,
        jump
    }
    PlayerSituation nowSituation = PlayerSituation.walk;

    //プレイヤーの生死状態
    public enum PlayerSurvival
    { 
        life,                   //生存状態
        collisionDeath,         //衝突による死亡状態
        fallDeath               //落下による死亡状態
    }
    PlayerSurvival nowSurvival = PlayerSurvival.life;

    //初期の向いてる方角を前のした時の現在のプレイヤー向いている方向
    public enum PlayerDirection
    {
        front,
        right,
        back,
        left
    }
    PlayerDirection nowDirection = PlayerDirection.front;


    void Update()
    {
        //デルタ増加
        this.delta += Time.deltaTime;
    }


    /// <summary>
    /// 3秒後状態を切りかえるコルーチン
    /// </summary>
    /// <returns></returns>
    public IEnumerator ChangeSituation()
    {
        //3秒待機
        yield return new WaitForSeconds(3f);
        //Debug.Log("ステータスコルーチン実行");
        //状態を切り替え
        this.nowSituation = PlayerSituation.run;
    }

    /// <summary>
    /// 現在のプレイヤーの状態を返す
    /// </summary>
    public PlayerSituation GetNowPlayerSituation()
    {
        return this.nowSituation;
    }

    /// <summary>
    /// 現在のプレイヤーの方向を返す
    /// </summary>
    public PlayerDirection GetNowPlayerDirection()
    {
        return this.nowDirection;
    }

    /// <summary>
    /// 現在のプレイヤーの生死状態を返す
    /// </summary>
    public PlayerSurvival GetNowPlayerSurvival()
    {
        return this.nowSurvival;
    }

    /// <summary>
    /// 状態を接地状態に応じて更新する
    /// </summary>
    /// <param name="GroundFlg">接地フラグ</param>
    /// <param name="flick">現在の入力状態</param>
    /// <param name="turnGroundFlg">ターン可能な地面との接地フラグ</param>
    public void SituationUpdate(bool GroundFlg, ScreenInput.FlickDirection flick, bool turnGroundFlg)
    {
        //ジャンプ状態から地面についた場合ステータスを変更
        if (GroundFlg == true && this.nowSituation == PlayerSituation.jump)
        {
            this.nowSituation = PlayerSituation.run;
        }

        //フリックの状態に応じてステータスを変更
        //プレイヤーが走っている状態のときはジャンプに切り替える
        if (flick == ScreenInput.FlickDirection.UP && this.nowSituation == PlayerSituation.run)
        {
            this.nowSituation = PlayerSituation.jump;
        }

        //向きを変える処理
        //ターン可能な地面にいるかの確認
        //走り状態化の確認
        if(flick == ScreenInput.FlickDirection.RIGHT && this.delta > this.rotationSpan && nowSituation == PlayerSituation.run && turnGroundFlg == true)
        {
            ChangeDirection(true);
            //デルタ初期化
            this.delta = 0;
        }
        if(flick == ScreenInput.FlickDirection.LEFT && this.delta > this.rotationSpan && nowSituation == PlayerSituation.run && turnGroundFlg == true)
        {
            ChangeDirection(false);
            //デルタ初期化
            this.delta = 0;
        }
  
    }

    /// <summary>
    /// プレイヤーの方向を変える
    /// </summary>
    /// <param name="rightFlg">右向きの回転かのフラグ</param>
    void ChangeDirection(bool rightFlg)
    {
        //現在の方向と回転方向に応じた処理
        switch(this.nowDirection)
        {
            case PlayerDirection.front:
                if(rightFlg == true)
                {
                    this.nowDirection = PlayerDirection.right;
                    Debug.Log("プレイヤーの方向変更(右)");
                }
                else
                {
                    this.nowDirection = PlayerDirection.left;
                    Debug.Log("プレイヤーの方向変更(左)");
                }
                break;
            case PlayerDirection.right:
                if (rightFlg == true)
                {
                    this.nowDirection = PlayerDirection.back;
                    Debug.Log("プレイヤーの方向変更(後)");
                }
                else
                {
                    this.nowDirection = PlayerDirection.front;
                    Debug.Log("プレイヤーの方向変更(前)");
                }
                break;
            case PlayerDirection.back:
                if (rightFlg == true)
                {
                    this.nowDirection = PlayerDirection.left;
                    Debug.Log("プレイヤーの方向変更(左)");
                }
                else
                {
                    this.nowDirection = PlayerDirection.right;
                    Debug.Log("プレイヤーの方向変更(右)");
                }
                break;
            case PlayerDirection.left:
                if (rightFlg == true)
                {
                    this.nowDirection = PlayerDirection.front;
                    Debug.Log("プレイヤーの方向変更(前)");
                }
                else
                {
                    this.nowDirection = PlayerDirection.back;
                    Debug.Log("プレイヤーの方向変更(後)");
                }
                break;
        }
        
    }

    /// <summary>
    /// プレイヤーの生死判定
    /// </summary>
    /// <param name="changeScene_delegate">リザルトシーンへの切り替えデリゲート</param>
    /// <param name="ply_fallSound_delegate">落下音再生のデリゲート</param>
    /// <param name="collisionFlg">プレイヤーの衝突フラグ</param>
    public void SurvivalChek(SceneController.changeScene_delegate changeScene_delegate, SoundController.ply_playerSound_delegate ply_fallSound_delegate, bool collisionFlg)
    {
        //プレヤーの座標が落下ボーダーより下にないかの確認
        if(parent_transform.position.y < this.playerFallBorder_y)
        {
            //落下サウンド再生
            ply_fallSound_delegate();
            //デリゲートでシーンをリザルトに変更
            StartCoroutine(changeScene_delegate(1f));
            //プレイヤーの生存状態を変更
            this.nowSurvival = PlayerSurvival.fallDeath;
        }
        //衝突フラグが立っているかを確認
        if(collisionFlg == true)
        {
            //衝突音再生

            //デリゲートでシーンをリザルトに変更
            StartCoroutine(changeScene_delegate(2.1f));
            //プレイヤーの生存状態を変更
            this.nowSurvival = PlayerSurvival.collisionDeath;
        }
    }
}
