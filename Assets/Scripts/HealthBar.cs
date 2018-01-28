using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Unit Unit;
    public Image HealthFill;

	// Use this for initialization
	void Start () {
		
	}
	
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
