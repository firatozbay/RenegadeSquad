using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsUI : MonoBehaviour {

    public Camera Camera;

    void Awake()
    {
        GameManager.Instance.AddToList(this);
    }
}
