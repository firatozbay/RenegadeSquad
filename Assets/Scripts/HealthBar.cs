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

    public Camera Camera;

	// Update is called once per frame
	void LateUpdate () {
        if (Unit != null)
        {
            //var screenPoint = Vector3(Input.mousePosition);
            //screenPoint.z = 10.0f; //distance of the plane from the camera
            //transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
            Vector2 pos = Camera.WorldToViewportPoint(Unit.transform.position);
            
            //Vector2 pos = RectTransformUtility.WorldToScreenPoint(Frigate.TacticalCameraInstance, Unit.transform.position);
            if (Camera.targetDisplay == 0)
                transform.position = Camera.ViewportToScreenPoint(pos) + new Vector3(0, 50, 0);
            else
                transform.localPosition = new Vector2(pos.x*960-430,pos.y*540-170);
        } else
        {
            Destroy(gameObject);
        }
    }
}
