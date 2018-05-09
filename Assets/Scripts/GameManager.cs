using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public ControllerManager ControllerManager;

    public Transform PlayerList;

    public Transform PlayerStationsParent;
    public Transform EnemyStationsParent;

    public int PlayerStationCount;
    public int EnemyStationCount;

    public Text GameWinLose;

    private void Awake()
    {
        Instance = this;
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
        var ps = PlayerStationsParent.GetComponentsInChildren<Station>();
        var es = EnemyStationsParent.GetComponentsInChildren<Station>();
        PlayerStationCount = ps.Length;
        EnemyStationCount = es.Length;
    }
    // Use this for initialization
    void Start () {
        ControllerManager = new ControllerManager();
        ControllerManager.Instance = ControllerManager;
	    int size = PlayerList.transform.childCount;
        for (int i = 0; i < size; i++)
	    {
	        var cam = PlayerList.transform.GetChild(i).GetComponentInChildren<Camera>();
            var fighter = PlayerList.transform.GetChild(i).GetComponentInChildren<Fighter>();
            fighter.ControllerIndex = (ControllerManager.ControllerIndex) i;
            fighter.NameText.text = GetName(i);

            if (size == 2)
	            cam.rect = new Rect(i * 0.5f, 0.0f, 0.5f, 1.0f);
	        else if (size > 2)
	            cam.rect = new Rect((i % 2) * 0.5f, i >= 2 ? 0.0f : 0.5f, 0.5f, 0.5f);
	    }
    }
	
	// Update is called once per frame
	void Update () {
		if(PlayerStationCount == 0) {
            GameWinLose.text = "YOU LOST";
            GameWinLose.gameObject.SetActive(true);
        }else if(EnemyStationCount == 0)
        {
            GameWinLose.text = "YOU WIN";
            GameWinLose.gameObject.SetActive(true);
        }
	}

    string GetName(int i)
    {
        switch (i)
        {
            case 0:
                return "ALPHA";
            case 1:
                return "BRAVO";
            case 2:
                return "CHARLIE";
            case 3:
                return "DELTA";
            default:
                return "";
        }
    }
}
