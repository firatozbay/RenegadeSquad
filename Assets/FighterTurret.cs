using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterTurret : MonoBehaviour {

    public Fighter Fighter;
    public float WeaponCharge;

    public GameObject MissilePrefab;
    
    // Update is called once per frame
    void Update()
    {
        if (WeaponCharge < 4.99f)
        {
            WeaponCharge += 5*Time.deltaTime;
            if (WeaponCharge > 4.98f)
            {
                WeaponCharge = 5.0f;
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        var unit = col.GetComponent<Unit>();
        if (unit != null && unit.UnitAlignment != Fighter.UnitAlignment)
        {
            Fighter.Target = unit.transform.position;
            Attack(unit);
        }
    }

    void Attack(Unit unit)
    {
        if (WeaponCharge > 4.98) { 
            var go = Instantiate(MissilePrefab, transform.position, transform.rotation);
            go.GetComponent<FighterMissile>().Fighter = Fighter;
            WeaponCharge = 0;
        }
    }
}
