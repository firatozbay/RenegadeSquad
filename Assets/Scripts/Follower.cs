﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

    public Transform Target;

    private Vector3 _initialDistance;

    // Use this for initialization
    void Start()
    {
        _initialDistance = transform.position - Target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Target != null)
            transform.position = Target.position + _initialDistance;
        else
        {
            var cam = GetComponent<Camera>();
            cam.clearFlags = CameraClearFlags.SolidColor;
            cam.backgroundColor = Color.black;
            cam.cullingMask = 0;

        }
    }
}
