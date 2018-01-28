using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(()=>StartGame());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartGame()
    {
        Application.LoadLevel("MainGame");
    }
}
