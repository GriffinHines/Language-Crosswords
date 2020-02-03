using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (Translate.language == "English")
            text.SetText("Quit");
        else if (Translate.language == "Spanish")
            text.SetText("Dejar");
        else if (Translate.language == "French")
            text.SetText("Quitter");
        else if (Translate.language == "Russian")
            text.SetText("Уволиться");
        else if (Translate.language == "Zulu")
            text.SetText("Yekela");
        text.fontSize = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
