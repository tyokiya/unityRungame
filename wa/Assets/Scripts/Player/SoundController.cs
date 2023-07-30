using System.Collections;
using System.Collections.Generic;
using UnityEngine;
////////////////////////////////////
// プレイヤーのサウンドを管理するマネージャースクリプト
////////////////////////////////////
public class SoundController : MonoBehaviour
{
    //インスペクターから設定
    //オーディオソースを入れる変数
    [SerializeField] AudioSource audioSource_object;
    //足音
    [SerializeField] AudioClip foot_sound;
    //落下音
    [SerializeField] AudioClip fall_sound;
    //衝突音
    [SerializeField] AudioClip collision_sound;

    //歩きの足音スパン
    float walk_span = 0.5f;
    //走りの足音スパン
    float run_span = 0.3f;
    //足音のデルタ
    float foot_sound_delta = 0;

    //サウンド再生時のデリゲート定義
    public delegate void ply_playerSound_delegate();

    /// <summary>
    /// 現在のプレイヤーの状態に応じて移動音再生
    /// </summary>
    /// <param name="situation">現在のプレイヤーの状態</param>
    public void PlyWalkSound(Status.PlayerSituation situation)
    {
        //現在の状態を見てサウンド再生
        if(situation == Status.PlayerSituation.walk && this.foot_sound_delta > this.walk_span)
        {
            //足音再生
            this.audioSource_object.PlayOneShot(this.foot_sound);
            //デルタ初期化
            this.foot_sound_delta = 0;
        }
        else if(situation == Status.PlayerSituation.run && this.foot_sound_delta > this.run_span)
        {
            //足音再生
            this.audioSource_object.PlayOneShot(this.foot_sound);
            //デルタ初期化
            this.foot_sound_delta = 0;
        }
        //デルタ増加
        this.foot_sound_delta += Time.deltaTime;
    }

    /// <summary>
    /// 落下音再生
    /// </summary>
    public void PlyFallSound()
    {
        this.audioSource_object.PlayOneShot(this.fall_sound);
    }
}
