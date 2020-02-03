using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Play : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (Translate.language == "English")
            text.SetText("PLAY");
        else if (Translate.language == "Spanish")
            text.SetText("JUGAR");
        else if (Translate.language == "French")
            text.SetText("JOUER");
        else if (Translate.language == "Russian")
            text.SetText("ИГРАТЬ");
        else if (Translate.language == "Zulu")
            text.SetText("DLALA");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
