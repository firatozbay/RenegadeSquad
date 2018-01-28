using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public enum Alignment { Player = 0, Enemy = 1 }

    public Alignment UnitAlignment;

    public GameObject ExplosionPrefab;
    public GameObject HealthBarPrefab;

    public Image HealthBarImage;

    private int _health;
    public int FullHealth =100;
    public int Health
    {
        get { return _health; }
        set
        {
            _health = value;
            HealthBarImage.fillAmount = (float)_health / (float)FullHealth;
            if (_health <= 0)
            {
                Explode();
            }
        }
    }


    public virtual void Start()
    {
        var go = Instantiate(HealthBarPrefab, UnitsUI.Instance.transform);
        var health = go.GetComponent<HealthBar>();
        health.Unit = this;
        HealthBarImage = health.HealthFill;
    }
    public void Explode()
    {
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}
