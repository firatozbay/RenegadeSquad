using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Fighter Fighter;

    private float _timer;
    private Rigidbody _rigidbody;

	// Use this for initialization
	void Start () {
        _timer = 2;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.forward * 75,ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
        _timer -= Time.deltaTime;
        if(_timer < 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        var unit = other.GetComponent<Unit>();
        if (unit != null && unit.UnitAlignment != Fighter.UnitAlignment)
        {
            Debug.Log("qwer");
            Damage(unit);
        }
    }

    void Damage(Unit unit)
    {
        unit.Health -= 20;
        Destroy(gameObject);
    }
}
