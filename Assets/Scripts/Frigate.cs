using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frigate : Unit
{
    public Camera TacticalCamera;
    public LineRenderer MovementLine;
    public Transform Indicator;
    private Vector3 _target;

	// Use this for initialization
	void Start ()
	{
	    Health = 1000;
	    _target = transform.position;
	    Indicator.position = _target;
    }

    // Update is called once per frame
    void Update ()
	{
	    if (Input.GetMouseButtonDown(1))
	    {
	        RaycastHit hit;
	        Ray ray = TacticalCamera.ScreenPointToRay(Input.mousePosition);
	        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
            if (Physics.Raycast(ray, out hit))
	        {
	            _target = new Vector3(hit.point.x,transform.position.y,hit.point.z);
	            Indicator.position = _target;
	        }
	    }
	    Vector3 relativePos = _target - transform.position;
	    Quaternion rotation = Quaternion.LookRotation(relativePos);
        if (Quaternion.Angle(transform.rotation, rotation) > 0.1f)
	    {
	        // fast rotation
	        float rotSpeed = 0.05f;

	        // distance between target and the actual rotating object
	        Vector3 D = _target - transform.position;

	        // calculate the Quaternion for the rotation
	        Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(D), rotSpeed * Time.deltaTime);

	        //Apply the rotation 
	        transform.rotation = rot;
            transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y, 0);
        }
	    if (Vector3.Distance(transform.position, _target) > 0.2f)
	    {
	        transform.position = Vector3.MoveTowards(transform.position, _target, 4*Time.deltaTime);
            MovementLine.SetPosition(0,transform.position);
	        MovementLine.SetPosition(1, _target);

        }
    }
}
