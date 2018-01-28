using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fighter : Unit {

    public ControllerManager.ControllerIndex ControllerIndex;

    public GameObject Bullet;

    private Rigidbody _rigidbody;
    
    private float _contFireTimer;

    private float _enemyTimer;

    private Vector3 _target;

    // Use this for initialization
    public override void Start () {
        base.Start();
        FullHealth = 100;
        Health = 100;
        _rigidbody = GetComponent<Rigidbody>();
        _contFireTimer = 0;

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

    // Update is called once per frame
    void Update ()
	{
        if(UnitAlignment == Alignment.Player)
            ControllerManager.Instance.GetCommand(this);
        else
        {
            _enemyTimer += Time.deltaTime;
            if (_enemyTimer > 10)
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
            Vector3 relativePos = _target - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            if (Quaternion.Angle(transform.rotation, rotation) > 0.1f)
            {
                // fast rotation
                float rotSpeed = 360f;

                // distance between target and the actual rotating object
                Vector3 D = _target - transform.position;

                // calculate the Quaternion for the rotation
                Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(D), rotSpeed * Time.deltaTime);

                //Apply the rotation 
                transform.rotation = rot;
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }

            if (Vector3.Distance(transform.position, _target) > 0.2f)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target, 30 * Time.deltaTime);
            }
        }
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
