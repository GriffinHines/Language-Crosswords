using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WellDone : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject;
        if (Menu.puzzleLanguage == "English")
                text.SetText("Well Done!");
        else if (Menu.puzzleLanguage == "Spanish")
                text.SetText("Hurra!");
        else if (Menu.puzzleLanguage == "French")
                text.SetText("Hourra!");
        else if (Menu.puzzleLanguage == "Russian")
                text.SetText("Ура!");
        else if (Menu.puzzleLanguage == "Zulu")
                text.SetText("Hooray!");
        text.fontSize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GenerateBoard.wordCount <= PlayGame.correctCount)
        {
            text.fontSize = 0.8F;
        }
    }
}
