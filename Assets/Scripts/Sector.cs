using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour {

    public Unit.Alignment SectorAlignment;

    public GameObject EnemyButtonsPrefab;
    public GameObject FriendlyButtonsPrefab;

    public int SectorIndex;

	// Use this for initialization
	void Start () {
        GameObject go;
        if (SectorAlignment == Unit.Alignment.Player)
        {
            go = Instantiate(FriendlyButtonsPrefab, SectorsUI.Instance.transform);
        }
        else
        {
            go = Instantiate(EnemyButtonsPrefab, SectorsUI.Instance.transform);
        }
        var buttons = go.GetComponent<SectorButtons>();
        buttons.Sector = this;
        var transmits = buttons.GetComponentsInChildren<SectorTransmitButton>();
        foreach(var transmit in transmits)
        {
            transmit.Sector = this;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Fighter>() != null)
        {
            var fighter = other.GetComponent<Fighter>();
            if (fighter.UnitAlignment == Unit.Alignment.Player)
                fighter.SetSector(SectorIndex);
        }
    }
}
