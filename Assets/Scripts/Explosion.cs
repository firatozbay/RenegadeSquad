﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 1)
        {
            Destroy(gameObject);
        }
    }
    
}
