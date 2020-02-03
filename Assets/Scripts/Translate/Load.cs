using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Load : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (Translate.language == "English")
            text.SetText("Load");
        else if (Translate.language == "Spanish")
            text.SetText("Carga");
        else if (Translate.language == "French")
            text.SetText("Charge");
        else if (Translate.language == "Russian")
            text.SetText("нагрузка");
        else if (Translate.language == "Zulu")
            text.SetText("Layisha");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
