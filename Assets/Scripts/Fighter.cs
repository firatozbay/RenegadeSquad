using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fighter : Unit {

    public ControllerManager.ControllerIndex ControllerIndex;

    public GameObject Bullet;

    private Rigidbody _rigidbody;
    
    private float _contFireTimer;

    // Use this for initialization
    public override void Start () {
        base.Start();
        FullHealth = 100;
        Health = 100;
        _rigidbody = GetComponent<Rigidbody>();
        _contFireTimer = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
        ControllerManager.Instance.GetCommand(this);
	}
    /*
    public void Move(float x, float y)
    {
        //transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, new Vector3(transform.eulerAngles.x, Mathf.Tan(y/x)* Mathf.Rad2Deg, transform.eulerAngles.z), 150 * Time.deltaTime);
         transform.rotation =   Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(transform.eulerAngles.x, Mathf.Tan(y / x) * Mathf.Rad2Deg, transform.eulerAngles.z)), 150 * Time.deltaTime);
        _rigidbody.AddForce(transform.forward * 5);
    }*/

    public void UseCommand(ControllerManager.Command command)
    {
        int n = 150;
        int m = 5;
        if (command == ControllerManager.Command.Pause)
        {
        }
        if (command == ControllerManager.Command.Up)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(0, 0, 0, 1), n * Time.deltaTime);
            //transform.Translate(Vector3.forward * m * Time.deltaTime);
            _rigidbody.AddForce(transform.forward * m);

        }
        else if (command == ControllerManager.Command.Left)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(0, -0.707f, 0, 0.707f), n * Time.deltaTime);
            //transform.Translate(Vector3.forward * m * Time.deltaTime);
            _rigidbody.AddForce(transform.forward * m);

        }
        else if (command == ControllerManager.Command.Down)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(0, 1, 0, 0), n * Time.deltaTime);
            //transform.Translate(Vector3.forward * m * Time.deltaTime);
            _rigidbody.AddForce(transform.forward * m);

        }
        else if (command == ControllerManager.Command.Right)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(0, 0.707f, 0, 0.707f), n * Time.deltaTime);
            //transform.Translate(Vector3.forward * m * Time.deltaTime);
            _rigidbody.AddForce(transform.forward * m);

        }
        else if (command == ControllerManager.Command.UpLeft)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(0, -0.383f, 0, 0.924f), n * Time.deltaTime);
            //transform.Translate(Vector3.forward * m * Time.deltaTime);
            _rigidbody.AddForce(transform.forward * m);

        }
        else if (command == ControllerManager.Command.UpRight)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(0, 0.383f, 0, 0.924f), n * Time.deltaTime);
            //transform.Translate(Vector3.forward * m * Time.deltaTime);
            _rigidbody.AddForce(transform.forward * m);

        }
        else if (command == ControllerManager.Command.DownLeft)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(0, -0.924f, 0, 0.383f), n * Time.deltaTime);
            //transform.Translate(Vector3.forward * m * Time.deltaTime);
            _rigidbody.AddForce(transform.forward * m);

        }
        else if (command == ControllerManager.Command.DownRight)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(0, 0.924f, 0, 0.383f), n * Time.deltaTime);
            //transform.Translate(Vector3.forward * m * Time.deltaTime);
            _rigidbody.AddForce(transform.forward * m);

        }

        else if (command == ControllerManager.Command.Fire)
        {
            Fire();
        }

        else if (command == ControllerManager.Command.ContFire)
        {
            _contFireTimer += Time.deltaTime;
            if (_contFireTimer > 0.15f)
            {
                _contFireTimer = 0;
                Fire();
            }
        }

        else if (command == ControllerManager.Command.Thrust)
        {
            _rigidbody.AddForce(transform.forward * m*10);
        }

        else if (command == ControllerManager.Command.Break)
        {
            _rigidbody.velocity = Vector3.Lerp(_rigidbody.velocity,Vector3.zero, Time.deltaTime);
            _rigidbody.angularVelocity = Vector3.Lerp(_rigidbody.angularVelocity, Vector3.zero, Time.deltaTime);
        }
    }

    void Fire()
    {
        var go = Instantiate(Bullet, transform.position, transform.rotation);
        go.GetComponent<Bullet>().Fighter = this;
        _rigidbody.AddForce(transform.forward*-1*0.2f,ForceMode.Impulse);
    }
}
