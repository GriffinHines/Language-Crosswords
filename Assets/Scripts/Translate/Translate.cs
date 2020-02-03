using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Translate : MonoBehaviour
{
    public static string language;
    public Dropdown translate;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Options();
    }

    public void ChooseLanguage()
    {
        switch (translate.value)
        {
            case 0:
                language = "English";
                break;
            case 1:
                language = "Spanish";
                break;
            case 2:
                language = "French";
                break;
            case 3:
                language = "Russian";
                break;
            case 4:
                language = "Zulu";
                break;
        }

    }

    public void Options()
    {
        if (language == "English")
            text.SetText("Options");
        else if (language == "Spanish")
            text.SetText("Opciones");
        else if (language == "French")
            text.SetText("Les Options");
        else if (language == "Russian")
            text.SetText("Параметры");
        else if (language == "Zulu")
            text.SetText("Izinketho");
    }
}
