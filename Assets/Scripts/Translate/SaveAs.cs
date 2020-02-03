using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveAs : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (Translate.language == "English")
            text.SetText("Save as");
        else if (Translate.language == "Spanish")
            text.SetText("Guardar como");
        else if (Translate.language == "French")
            text.SetText("Enregistrer sous");
        else if (Translate.language == "Russian")
            text.SetText("Сохранить как");
        else if (Translate.language == "Zulu")
            text.SetText("Igcine njenge");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
