﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateSelf : MonoBehaviour
{

    public Vector3 rotateSpeed;

    private void Start()
    {
        DOTween.To(() => rotateSpeed, x => rotateSpeed = x, new Vector3(-90, -60, -30), 5).SetLoops(-1, LoopType.Yoyo);
    }

    private void Update()
    {
        if (GameMode.instance.mode == Mode.Auto)
        {
            transform.Rotate(rotateSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime);
        }
    }


}
