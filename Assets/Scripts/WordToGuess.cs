using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordToGuess : MonoBehaviour
{
    private GameObject displayBar;
    private Text displayText;
    // Start is called before the first frame update
    void Start()
    {
        displayBar = GameObject.Find("WordDisplay");
        displayText = GetComponentInChildren<Text>();
        displayBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayGame.keyboardOpen)
        {
            displayBar.SetActive(true);
            displayText.text = PlayGame.hint;
        }
        else
        {
            displayBar.SetActive(false);
        }
    }
}
