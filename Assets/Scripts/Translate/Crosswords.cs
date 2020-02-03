using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crosswords : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (Translate.language == "English")
            text.SetText("Crosswords");
        else if (Translate.language == "Spanish")
            text.SetText("Crucigramas");
        else if (Translate.language == "French")
            text.SetText("Mots Croisés");
        else if (Translate.language == "Russian")
            text.SetText("Кроссворды");
        else if (Translate.language == "Zulu")
            text.SetText("Umabhebhana");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
