using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomGame : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (Translate.language == "English")
            text.SetText("Custom Game");
        else if (Translate.language == "Spanish")
            text.SetText("Juego Personalizado");
        else if (Translate.language == "French")
            text.SetText("Jeu Personnalisé");
        else if (Translate.language == "Russian")
            text.SetText("Кастомная Игра");
        else if (Translate.language == "Zulu")
            text.SetText("Umdlalo Wokwezifiso");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
