using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberOfWords : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (Translate.language == "English")
            text.SetText("Number of Words");
        else if (Translate.language == "Spanish")
            text.SetText("Número de palabras");
        else if (Translate.language == "French")
            text.SetText("Nombre de mots");
        else if (Translate.language == "Russian")
            text.SetText("Число слов");
        else if (Translate.language == "Zulu")
            text.SetText("Inani lamagama");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
