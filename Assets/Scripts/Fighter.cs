using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fighter : MonoBehaviour {

    public ControllerManager.ControllerIndex ControllerIndex;

    public GameObject Bullet;

    private Rigidbody _rigidbody;

    
    private int _health;
    private float _contFireTimer;

    public int Health
    {
        get { return _health; }
        set
        {
            _health = value;
            HealthBarImage.fillAmount = _health / 100f;
        }
    }

    public Image HealthBarImage;

    // Use this for initialization
    void Start () {
        _rigidbody = GetComponent<Rigidbody>();
        _contFireTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        ControllerManager.Instance.GetCommand(this);
	}
    
    public void UseCommand(ControllerManager.Command command)
    {
        int n = 100;
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
            _rigidbody.AddForce(transform.forward * m*5);
        }
    }

    void Fire()
    {
        var go = Instantiate(Bullet, transform.position, transform.rotation);
        _rigidbody.AddForce(transform.forward*-1*0.1f,ForceMode.Impulse);
    }
}
