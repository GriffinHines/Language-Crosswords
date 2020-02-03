using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Save : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (Translate.language == "English")
            text.SetText("SAVE");
        else if (Translate.language == "Spanish")
            text.SetText("GUARDAR");
        else if (Translate.language == "French")
            text.SetText("ENREGISTRER");
        else if (Translate.language == "Russian")
            text.SetText("СОХРАНИТЬ");
        else if (Translate.language == "Zulu")
            text.SetText("IGCINE");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
