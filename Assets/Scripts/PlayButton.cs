using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Dropdown translate;
    public Dropdown to;
    private static bool one;
    private static bool two;
    public static bool allWords;
    // Start is called before the first frame update
    void Start()
    {
        one = false;
        two = false;
        allWords = false;
        foreach (Button button in GetComponentsInChildren<Button>())
        {
            button.interactable = false;
        }

        if(translate)
            translate.onValueChanged.AddListener(delegate {
                TranslateValueChanged(translate);
            });

        if(to)
            to.onValueChanged.AddListener(delegate {
                ToValueChanged(to);
            });
    }

    // Update is called once per frame
    void Update()
    {
        //Turn button on when both language dropdown menus have been selected in challenges, or when all words are chosen in custom
        if((one && two || allWords))
        {
            foreach (Button button in GetComponentsInChildren<Button>())
            {
                button.interactable = true;
            }
        }
        else
        {
            foreach (Button button in GetComponentsInChildren<Button>())
            {
                button.interactable = false;
            }
        }
    }

    void TranslateValueChanged(Dropdown change)
    {
        one = true;
    }

    void ToValueChanged(Dropdown change)
    {
        two = true;
    }
}
