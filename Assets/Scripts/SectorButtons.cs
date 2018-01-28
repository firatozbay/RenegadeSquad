using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorButtons : MonoBehaviour {

    public Sector Sector;
	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Sector != null)
        {
            Vector2 pos = RectTransformUtility.WorldToScreenPoint(Frigate.TacticalCameraInstance, Sector.transform.position);
            transform.position = pos + new Vector2(0, 50);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
