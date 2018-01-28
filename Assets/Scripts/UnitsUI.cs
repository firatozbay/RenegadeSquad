using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsUI : MonoBehaviour {

    public static UnitsUI Instance;

    void Awake()
    {
        Instance = this;
    }
}
