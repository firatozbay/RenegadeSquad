using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterMissile : MonoBehaviour {
    public Fighter Fighter;
    public GameObject ExplosionPrefab;

    private float _speed;
    private float _timer;

    void Start()
    {
        _speed = 50;
        _timer = 5;
    }

    void Update()
    {
        _speed += 3f * Time.deltaTime;
        transform.Translate(Vector3.forward * Time.deltaTime*_speed);
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        var unit = col.GetComponent<Unit>();
        if (unit != null && unit.UnitAlignment != Fighter.UnitAlignment)
        {
            Damage(unit);
            Debug.Log("damage");
        }
    }

    void Damage(Unit unit)
    {
        if (unit != null)
        {
            unit.Health -= 5;
        }
        Destroy(gameObject);
    }
}