using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCntroller : MonoBehaviour
{
    void Awake()
    {
        //�t���[�����[�g�Œ�
        Application.targetFrameRate = 60;
    }
}
