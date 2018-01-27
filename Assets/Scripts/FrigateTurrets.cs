using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrigateTurrets : MonoBehaviour
{
    public Frigate Frigate;

    public float WeaponCharge;

    public GameObject MissilePrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (WeaponCharge < 4.99f)
	    {
	        WeaponCharge += Time.deltaTime;
	        if (WeaponCharge > 4.98f)
	        {
	            WeaponCharge = 5.0f;
	        }
	    }
	}

    void OnTriggerStay(Collider col)
    {
        var unit = col.GetComponent<Unit>();
        if ( unit != null && unit.UnitAlignment != Frigate.UnitAlignment)
        {
            Attack(unit);
        }
    }

    void Attack(Unit unit )
    {
        if (WeaponCharge> 4.98)
        {
            var go = Instantiate(MissilePrefab, transform.position, transform.rotation);
            go.GetComponent<Missile>().Frigate = Frigate;
            go.GetComponent<Missile>().Target = unit.transform;
            WeaponCharge = 0;
        }
    }
}
