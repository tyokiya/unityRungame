﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// フレームレートの制御スクリプト
////////////////////////////////////

public class FrameCntroller : MonoBehaviour
{
    void Awake()
    {
        //フレームレート固定
        Application.targetFrameRate = 60;
    }
}