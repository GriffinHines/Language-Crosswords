using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cancel : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (Translate.language == "English")
            text.SetText("CANCEL");
        else if (Translate.language == "Spanish")
            text.SetText("CANCELAR");
        else if (Translate.language == "French")
            text.SetText("ANNULER");
        else if (Translate.language == "Russian")
            text.SetText("ОТМЕНА");
        else if (Translate.language == "Zulu")
            text.SetText("KULULA");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
