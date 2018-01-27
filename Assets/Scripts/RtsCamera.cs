using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RtsCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float m = 300;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime*m,Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime*m, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime*m, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime*m, Space.World);
        }
        transform.Translate(Vector3.forward *m* (Input.GetAxis("Mouse ScrollWheel")));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-750,750), transform.position.y, Mathf.Clamp(transform.position.z,-300,300));
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.position.y,150,500), transform.localPosition.z);
    }
}
