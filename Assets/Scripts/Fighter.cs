using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fighter : Unit {
    //Universal stuff
    public GameObject Bullet;

    private Rigidbody _rigidbody;

    //Player stuff
    public ControllerManager.ControllerIndex ControllerIndex;

    public Text NameText; // UI Text for player
    public Text DeathTimerText; //UI Text for player

    public Image[] SectorImages;    //Set in editor

    public float DeathTimer { get; set; }

    private Vector3 _initialPosition;
    private float _contFireTimer;

    //Enemy stuff
    public Vector3 Target { get; set; }
    private float _enemyTimer;
    

    // Use this for initialization
    public override void Start () {
        base.Start();
        _initialPosition = transform.position;
        DeathTimer = -1;
        FullHealth = 100;
        Health = 100;
        _rigidbody = GetComponent<Rigidbody>();
        _contFireTimer = 0;     //time to fire for continous pressing

        _enemyTimer = Random.Range(5, 10);
        var rand = Random.Range(0, 10);
        if (rand > 6)
        {
            Target = new Vector3(Random.Range(-1000, 0), transform.position.y, Random.Range(-300, 300));
        }
        else
        {
            Target = new Vector3(Random.Range(0, 1000), transform.position.y, Random.Range(-300, 300));
        }

    }

    // Update is called once per frame
    void Update ()
	{
        if (UnitAlignment == Alignment.Player)
        {
            if(DeathTimer > 0)
            {
                DeathTimer -= Time.deltaTime;
                DeathTimerText.text = "Respawn in\n00:0" + DeathTimer.ToString("0");
                if (DeathTimer < 0)
                {
                    Respawn();
                    DeathTimerText.text = "";
                }
            }
            else
            {
                ControllerManager.Instance.GetCommand(this);
            }

        }
        else //Enemy
        {
            _enemyTimer -= Time.deltaTime;
            if (_enemyTimer < 0)
            {
                _enemyTimer = Random.Range(5, 10);
                var rand = Random.Range(0, 10);
                if (rand > 6)
                {
                    Target = new Vector3(Random.Range(-1000, 0), transform.position.y, Random.Range(-300, 300));
                }
                else
                {
                    Target = new Vector3(Random.Range(0, 1000), transform.position.y, Random.Range(-300, 300));
                }

            }
            Vector3 relativePos = Target - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            if (Quaternion.Angle(transform.rotation, rotation) > 0.1f)
            {
                // fast rotation
                float rotSpeed = 360f;

                // distance between target and the actual rotating object
                Vector3 D = Target - transform.position;

                // calculate the Quaternion for the rotation
                Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(D), rotSpeed * Time.deltaTime);

                //Apply the rotation 
                transform.rotation = rot;
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }

            if (Vector3.Distance(transform.position, Target) > 0.2f)
            {
                transform.position = Vector3.MoveTowards(transform.position, Target, 30 * Time.deltaTime);
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
    public override void Destroy()
    {
        if (UnitAlignment == Unit.Alignment.Player)
        {
            ToggleActivation(false);
            DeathTimer = 5;
        }
        else
        {
            base.Destroy();
        }
    }

    void ToggleActivation(bool enable)
    {
        var meshrenderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var meshrenderer in meshrenderers)
            meshrenderer.enabled = enable;

        GetComponent<Collider>().enabled = enable;
        GetComponentInChildren<TrailRenderer>().enabled = enable;

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.isKinematic = !enable;
        if(enable)
            Health = 100;
    }
    void Respawn()
    {
        transform.position = _initialPosition;
        ToggleActivation(true);
    }

    public void SetSector(int index)
    {
        foreach (var sector in SectorImages)
            sector.color = Color.black;
        SectorImages[index].color = Color.yellow;
    }
}
