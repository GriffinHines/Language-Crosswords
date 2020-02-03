using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AreYouSure : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (Translate.language == "English")
            text.SetText("Are you sure you want to quit?");
        else if (Translate.language == "Spanish")
            text.SetText("¿Seguro que quieres salir?");
        else if (Translate.language == "French")
            text.SetText("Êtes-vous sûr de vouloir quitter?");
        else if (Translate.language == "Russian")
            text.SetText("Вы уверены, что хотите выйти?");
        else if (Translate.language == "Zulu")
            text.SetText("Uqinisekile ukuthi ufuna ukuyeka?");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
