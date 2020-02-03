using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomPuzzleButton : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (Translate.language == "English")
            text.SetText("Custom Puzzle");
        else if (Translate.language == "Spanish")
            text.SetText("Personalizada");
        else if (Translate.language == "French")
            text.SetText("Personnalisé");
        else if (Translate.language == "Russian")
            text.SetText("Собственная");
        else if (Translate.language == "Zulu")
            text.SetText("Iphazili Yakho");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
