using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Frigate Frigate;
    public Transform Target;
    private float _speed;
    public GameObject ExplosionPrefab;

    void Start()
    {
        _speed = 20;
    }

    void Update()
    {
        _speed += 0.5f * Time.deltaTime;
        if (Target != null)
        {
            transform.LookAt(Target);
            transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * _speed);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        var unit = col.GetComponent<Unit>();
        if (unit != null && unit.UnitAlignment != Frigate.UnitAlignment)
        {
            Explode(unit);
        }
    }

    void Explode(Unit unit)
    {
        if(unit != null)
            Destroy(unit.gameObject);
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
