using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Top1000 : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (Translate.language == "English")
            text.SetText("Top 1000 Words");
        else if (Translate.language == "Spanish")
            text.SetText("Top 1000 palabras");
        else if (Translate.language == "French")
            text.SetText("1000 premiers mots");
        else if (Translate.language == "Russian")
            text.SetText("1000 лучших слов");
        else if (Translate.language == "Zulu")
            text.SetText("Okuphezulu kwe-1000");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
