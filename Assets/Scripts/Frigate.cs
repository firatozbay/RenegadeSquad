using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frigate : Unit
{
    public Camera TacticalCamera;
    public static Camera TacticalCameraInstance;
    public LineRenderer MovementLine;
    public Transform Indicator;
    private Vector3 _target;
    public LayerMask Mask;

    private float _enemyTimer;

	// Use this for initialization
	public override void Start ()
    {
        base.Start();
        _enemyTimer = 25;
        TacticalCameraInstance = TacticalCamera;
        FullHealth = 500;
        Health = 500;
        _target = transform.position;
	    Indicator.position = _target;
    }

    // Update is called once per frame
    void Update ()
	{
        if (UnitAlignment == Alignment.Player)
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                Ray ray = TacticalCamera.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
                if (Physics.Raycast(ray, out hit, 2000, Mask.value))
                {
                    _target = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                    Indicator.position = _target;
                }
            }
        }
        else
        {
            _enemyTimer += Time.deltaTime;
            if (_enemyTimer > 25)
            {
                _enemyTimer = 0;
                var rand = Random.Range(0, 10);
                if (rand > 6)
                {
                    _target = new Vector3(Random.Range(-1000, 0), transform.position.y, Random.Range(-300, 300));
                }
                else
                {
                    _target = new Vector3(Random.Range(0, 1000), transform.position.y, Random.Range(-300, 300));
                }
                
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
	        transform.position = Vector3.MoveTowards(transform.position, _target, ((UnitAlignment == Alignment.Enemy)?1.5f:1f)*4*Time.deltaTime);
            MovementLine.SetPosition(0,transform.position);
	        MovementLine.SetPosition(1, _target);

        }
    }
}
