using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadButton : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (Translate.language == "English")
            text.SetText("LOAD");
        else if (Translate.language == "Spanish")
            text.SetText("CARGA");
        else if (Translate.language == "French")
            text.SetText("CHARGE");
        else if (Translate.language == "Russian")
            text.SetText("НАГРУЗКИ");
        else if (Translate.language == "Zulu")
            text.SetText("LAYISHA");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
