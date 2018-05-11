using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FrigateTurrets : MonoBehaviour
{
    public Frigate Frigate;

    public float WeaponCharge;

    public GameObject MissilePrefab;

    private List<Unit> _unitsInRange;
    private int _currentIndex;

	// Use this for initialization
	void Start () {
        _unitsInRange = new List<Unit>();
        _currentIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    WeaponCharge += Time.deltaTime;
	    if (WeaponCharge > 4.98f)
	    {
            if (_unitsInRange.Any())
            {
                if (!Attack())
                    WeaponCharge = 5.0f;
                else
                    WeaponCharge = 0;
            }
            else
                WeaponCharge = 5.0f;
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Unit>() != null)
        {
            var unit = other.GetComponent<Unit>();
            if (!_unitsInRange.Contains(unit) && unit.UnitAlignment != Frigate.UnitAlignment)
            {
                _unitsInRange.Add(unit);
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Unit>()!=null)
        {
            var unit = other.GetComponent<Unit>();
            if (_unitsInRange.Contains(unit))
            {
                RemoveFromList(unit);
            }
        }
    }

    private void RemoveFromList(Unit unit)
    {
        if (_unitsInRange.IndexOf(unit) >= _currentIndex) 
            _currentIndex = Mathf.Max(0,(_currentIndex - 1));
        _currentIndex = _currentIndex % _unitsInRange.Count;

        _unitsInRange.Remove(unit);
    }
    
    /*
    void OnTriggerStay(Collider col)
    {
        var unit = col.GetComponent<Unit>();
        if ( unit != null && unit.UnitAlignment != Frigate.UnitAlignment)
        {
        }
    }*/

    bool Attack()
    {
        if (_unitsInRange.Count > _currentIndex)
        {
            if (_unitsInRange[_currentIndex] == null)
            {
                RemoveFromList(_unitsInRange[_currentIndex]);
                return false;
            }
            else 
            {
                var go = Instantiate(MissilePrefab, transform.position, transform.rotation);
                go.GetComponent<Missile>().Frigate = Frigate;
                go.GetComponent<Missile>().Target = _unitsInRange[_currentIndex].transform;
                _currentIndex = (_currentIndex + 1) % _unitsInRange.Count;
                return true;
            }
        }
        else
        {
            _currentIndex = Mathf.Max(0, _unitsInRange.Count - 1);
            return false;
        }
    }
}
