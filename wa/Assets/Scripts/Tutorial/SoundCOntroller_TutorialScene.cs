﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCOntroller_TutorialScene : MonoBehaviour
{
    //インスペクターから設定
    //オーディオソースを入れる変数
    [SerializeField] AudioSource audioSource_object;
    //決定音
    [SerializeField] AudioClip select_sound;

    /// <summary>
    /// セレクトサウンドの再生
    /// </summary>
    public void PlySelectSound()
    {
        this.audioSource_object.PlayOneShot(this.select_sound);
    }
}
