﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public enum Alignment { Player = 0, Enemy = 1 }

    public Alignment UnitAlignment;

    public GameObject ExplosionPrefab;

    private int _health;

    public int Health
    {
        get { return _health; }
        set
        {
            _health = value;
            //HealthBarImage.fillAmount = _health / 100f;
            if (_health <= 0)
            {
                Explode();
            }
        }
    }

    public Image HealthBarImage;

    public void Explode()
    {
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}