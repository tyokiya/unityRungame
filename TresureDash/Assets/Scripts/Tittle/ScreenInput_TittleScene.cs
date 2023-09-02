using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenInput_TittleScene : MonoBehaviour
{
    [Tooltip("カメラオブジェクト")][SerializeField] 
    GameObject camera_objet;

    void Update()
    {
        //var pos = _camera.ScreenToWorldPoint(Input.mousePosition + _camera.transform.forward * 10);
    }
}
