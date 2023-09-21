using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_Manager : MonoBehaviour
{
    [SerializeField][Tooltip("フェード処理オブジェクト")]
    Fade fade_obj;

    [SerializeField][Tooltip("フェード所要時間定数")]
    int fade_time;

    void Start()
    {
        //画面のフェードイン処理
        this.fade_obj.FadeIn(fade_time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
