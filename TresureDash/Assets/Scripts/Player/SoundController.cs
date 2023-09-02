﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
////////////////////////////////////
// プレイヤーのサウンドを管理するマネージャースクリプト
////////////////////////////////////
public class SoundController : MonoBehaviour
{
    //インスペクターから設定
    [Tooltip("オーディオソースオブジェクト")][SerializeField]
    AudioSource audioSource_object;
    
    //再生音
    [SerializeField] AudioClip foot_sound;
    [SerializeField] AudioClip fall_sound;
    [SerializeField] AudioClip jump_sound;
    [SerializeField] AudioClip collision_sound;
    [SerializeField] AudioClip getItem_sound;
    [SerializeField] AudioClip goal_sound;

    [Tooltip("足音(歩き)再生のスパン定数")]
    const float walkSound_span_const = 0.5f;
    [Tooltip("足音(走り)再生のスパン定数")]
    const float runSound_span_const = 0.3f;
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
        if(situation == Status.PlayerSituation.walk && this.foot_sound_delta > walkSound_span_const)
        {
            //足音再生
            this.audioSource_object.PlayOneShot(this.foot_sound);
            //デルタ初期化
            this.foot_sound_delta = 0;
        }
        else if(situation == Status.PlayerSituation.run && this.foot_sound_delta > runSound_span_const)
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

    /// <summary>
    /// 衝突音再生
    /// </summary>
    public void PlyCollisionSound()
    {
        this.audioSource_object.PlayOneShot(this.collision_sound);
    }

    /// <summary>
    /// ジャンプ音再生
    /// </summary>
    public void PlyJumpSound()
    {
        this.audioSource_object.PlayOneShot(this.jump_sound);
    }

    /// <summary>
    /// アイテム取得音再生
    /// </summary>
    public void PlyGetItemSound()
    {
        this.audioSource_object.PlayOneShot(this.getItem_sound);
    }

    /// <summary>
    /// ゴール音再生
    /// </summary>
    public void PlyGoalSound()
    {
        this.audioSource_object.PlayOneShot(this.goal_sound);
    }
}