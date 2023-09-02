﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// タイトルシーンのサウンドコントローラースクリプト
////////////////////////////////////

public class SoundCOntroller_TittleScene : MonoBehaviour
{
    //インスペクターから設定
    [Tooltip("オーディオソースオブジェクト")][SerializeField] 
    AudioSource audioSource_object;

    [SerializeField] AudioClip select_sound;

    /// <summary>
    /// セレクトサウンドの再生
    /// </summary>
    public void PlySelectSound()
    {
        this.audioSource_object.PlayOneShot(this.select_sound);
    }
}