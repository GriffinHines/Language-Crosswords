using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (Translate.language == "English")
            text.SetText("Cheat");
        else if (Translate.language == "Spanish")
            text.SetText("Engañar");
        else if (Translate.language == "French")
            text.SetText("Tricher");
        else if (Translate.language == "Russian")
            text.SetText("Чит");
        else if (Translate.language == "Zulu")
            text.SetText("Ukukopela");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
