using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public ControllerManager ControllerManager;

	// Use this for initialization
	void Start () {
        ControllerManager = new ControllerManager();
        ControllerManager.Instance = ControllerManager;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
