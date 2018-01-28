using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : Unit
{
    public override void Start()
    {
        base.Start();
        FullHealth = 250;
        Health = 250;
    }
    private void OnDestroy()
    {
        if (UnitAlignment == Alignment.Enemy)
        {
            GameManager.Instance.EnemyStationCount--;
        }
        else
        {
            GameManager.Instance.PlayerStationCount--;
        }
    }
}

