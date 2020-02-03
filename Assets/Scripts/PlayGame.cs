using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;
    public static bool keyboardOpen = false;
    ArrayList array = new ArrayList();
    Text text;
    static int wordNumber = -1;
    int doubleClick;
    public static int correctCount;
    public static string word;
    public static string hint;
    string guess;
    void Start()
    {
        correctCount = 0;
        wordNumber = -1;
        doubleClick = 0;
        word = "";
        hint = "";
        guess = "";
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("guess: " + guess);
        if (Input.GetMouseButtonDown(0))
        {
            ChangeColor();
        }

        if (keyboard != null)
        {
            if (!keyboard.done)
            {
                guess = keyboard.text;
                Debug.Log("keyBoard open, guess: " + guess + " word: " + word);
                keyboardOpen = true;
                if (!string.Equals(word, "") && string.Equals(word, guess, System.StringComparison.CurrentCultureIgnoreCase))
                {
                    Debug.Log("Equals");
                    RevealWord(wordNumber);
                    keyboard.text = "";
                    guess = "";
                }
            }
            else
                keyboardOpen = false;
        }
    }
    //Highlight tiles when clicked on
    void ChangeColor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //Unhilight previous tiles
        foreach (Renderer item in array)
        {
            item.material.SetColor("_Color", Color.white);
        }
        array = new ArrayList();
        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.gameObject == gameObject)
            {
                int location = System.Array.IndexOf(GenerateBoard.tiles, gameObject);
                Debug.Log(location);
                //change between horizontal and vertical on double click
                if (location == doubleClick)
                 {
                     if (wordNumber == GenerateBoard.tileNumber[location, 0])
                         wordNumber = GenerateBoard.tileNumber[location, 1];
                     else
                         wordNumber = GenerateBoard.tileNumber[location, 0];
                 }
                //select vertical word
                else if (GenerateBoard.tileNumber[location, 1] != 0)
                    wordNumber = GenerateBoard.tileNumber[location, 1];

                //select horizontal word
                else
                    wordNumber = GenerateBoard.tileNumber[location, 0];
                
                //doubleClick = location;
                for (int i = 0; i < 100; i++)
                {
                    if (wordNumber == 0)
                        return;
                    if (GenerateBoard.tileNumber[i, 0] == wordNumber || GenerateBoard.tileNumber[i, 1] == wordNumber)
                    {
                        Renderer rend = GenerateBoard.tiles[i].GetComponent<Renderer>();
                        Debug.Log(rend.material.color);
                        string color = rend.material.color.ToString();
                        Debug.Log(color);
                        if (!color.Equals("RGBA(0.000, 0.000, 0.000, 1.000)"))
                        {
                            rend.material.SetColor("_Color", Color.yellow);
                            array.Add(rend);
                        }
                            // Debug.Log(wordNumber);
                    }
                }
                if (wordNumber == 0)
                    wordNumber++;
                word = GenerateBoard.placedWords[wordNumber - 1];
                hint = GenerateBoard.hintWords[wordNumber - 1];
                keyboard = TouchScreenKeyboard.Open(guess, TouchScreenKeyboardType.Default, false);
            }
        }
    }

    //Reveal guessed word in tiles
    void RevealWord(int number)
    {
        for(int i = 0; i<100; i++)
        {
            if (GenerateBoard.tileNumber[i, 0] == number || GenerateBoard.tileNumber[i, 1] == number)
            {
                text = GenerateBoard.tiles[i].GetComponentInChildren<Text>();
                text.enabled = true;
            }
        }
        correctCount++;
    }
    public void Cheat()
    {
        guess = word;
        RevealWord(wordNumber);
    }
}
