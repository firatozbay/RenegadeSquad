using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SectorTransmitButton : MonoBehaviour {
    public Sector Sector;
    private Button _button;
    private Text _text;

    // Use this for initialization
    void Start()
    {
        _text = GetComponentInChildren<Text>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => OnClick());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick()
    {
        TransmissionText.Instance.TransmitMessage(_text.text+" on "+ Sector.name);
    }
}
