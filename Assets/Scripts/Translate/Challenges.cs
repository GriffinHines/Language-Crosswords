using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Challenges : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (Translate.language == "English")
            text.SetText("CHALLENGES");
        else if (Translate.language == "Spanish")
            text.SetText("DESAFÍOS");
        else if (Translate.language == "French")
            text.SetText("DÉFIS");
        else if (Translate.language == "Russian")
            text.SetText("ВЫЗОВЫ");
        else if (Translate.language == "Zulu")
            text.SetText("IZINSELELE");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
