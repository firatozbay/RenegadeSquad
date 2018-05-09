using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private Unit _unit;

    public Unit Unit { get { return _unit; }
        set
        {
            _unit = value;
            HealthFill.color = _unit.UnitAlignment == Unit.Alignment.Player ? PlayerColor : EnemyColor;
        }
    }
    public Image HealthFill;

    public Color PlayerColor;
    public Color EnemyColor;
    
	// Update is called once per frame
	void Update () {
        if (Unit != null)
        {
            Vector2 pos = RectTransformUtility.WorldToScreenPoint(Frigate.TacticalCameraInstance, Unit.transform.position);
            transform.position = pos + new Vector2(0, 50);
        }else
        {
            Destroy(gameObject);
        }
    }
}
