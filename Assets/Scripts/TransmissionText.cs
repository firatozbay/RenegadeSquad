using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class TransmissionText : MonoBehaviour
{
    public static TransmissionText Instance;

    public Text textBox;
    //Store all your text in this string array
    public string Sentence = "";
        
    int currentlyDisplayingText = 0;

    void Awake()
    {
        Instance = this;
        textBox = GetComponent<Text>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {

            StartCoroutine(AnimateText());
        }
    }

    //Note that the speed you want the typewriter effect to be going at is the yield waitforseconds (in my case it's 1 letter for every      0.03 seconds, replace this with a public float if you want to experiment with speed in from the editor)
    IEnumerator AnimateText()
    {

        for (int i = 0; i < (Sentence.Length + 1); i++)
        {
            textBox.text = Sentence.Substring(0, i);
            yield return new WaitForSeconds(.03f);
        }
    }

    public void TransmitMessage(string s)
    {
        Sentence = s;
        StartCoroutine(AnimateText());
    }
}
