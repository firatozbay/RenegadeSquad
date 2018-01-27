﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float _timer;
    private Rigidbody _rigidbody;

	// Use this for initialization
	void Start () {
        _timer = 1;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.forward * 75,ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
        _timer -= Time.deltaTime;
        if(_timer < 0)
        {
            Destroy(this);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        
    }
}