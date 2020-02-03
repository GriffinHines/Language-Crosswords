using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomTiles : MonoBehaviour
{
    public static string[] words;
    public static string[] translations;
    public static int wordNumber;
    public static bool loading;
    public GameObject[] text;
    public GameObject[] wordInput;
    public GameObject[] translationInput;
    private GameObject play;
    private GameObject load;
    public static GameObject savePanel;
    public static GameObject loadPanel;
    public GameObject makeSure;
    // Start is called before the first frame update
    void Start()
    {
        makeSure.SetActive(false);
        words = new string[30];
        translations = new string[30];
        loading = false;
        play = GameObject.Find("PlayGameObject");
        load = GameObject.Find("OpenLoad");
        savePanel = GameObject.Find("SavePanel");
        loadPanel = GameObject.Find("LoadPanel");
        savePanel.SetActive(false);

        //Words that display above input
        for (int i = 1; i < 32; i++)
        {
            text[i] = Instantiate(text[0], new Vector3(200, GameObject.Find("NumberOfWords").transform.position.y - 150*i, 0), Quaternion.identity);
            text[i].transform.parent = GameObject.Find("ScrollCanvas").transform;
            text[i].SetActive(false);
        }

        //Input boxes for word to translate
        for (int i = 1; i < 32; i++)
        {
            wordInput[i] = Instantiate(wordInput[0], new Vector3(155, GameObject.Find("NumberOfWords").transform.position.y - 50 - 150 * i, 0), Quaternion.identity);
            wordInput[i].transform.parent = GameObject.Find("ScrollCanvas").transform;
            wordInput[i].SetActive(false);
        }

        //Input boxes for translation of word
        for (int i = 1; i < 32; i++)
        {
            translationInput[i] = Instantiate(translationInput[0], new Vector3(470, GameObject.Find("NumberOfWords").transform.position.y - 50 - 150 * i, 0), Quaternion.identity);
            translationInput[i].transform.parent = GameObject.Find("ScrollCanvas").transform;
            translationInput[i].SetActive(false);
        }

        wordNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (loading)
            return;
        //convert input field to int
        if (!string.Equals(GetComponent<Text>().text, ""))
        wordNumber = System.Convert.ToInt32(GetComponent<Text>().text) + 1;
        else
            wordNumber = 0;

        //Wordnumber can't be greater than 31
        if (wordNumber > 31)
        {
            wordNumber = 31;
        }

        //Activate and deactivate input fields based on word number
        for (int i = 0; i < wordNumber; i++)
        {
            text[i].SetActive(true);
            wordInput[i].SetActive(true);
            translationInput[i].SetActive(true);
        }
        for (int i = wordNumber; i < 30; i++)
        {
            text[i].SetActive(false);
            wordInput[i].SetActive(false);
            translationInput[i].SetActive(false);
        }

        //Move play button to appropriate position
        play.transform.position = new Vector3(play.transform.position.x, wordInput[wordNumber].transform.position.y + 200, 0);
        savePanel.transform.position = new Vector3(savePanel.transform.position.x, play.transform.position.y - 350, 0);

        //Assign input field values to public arrays
        for (int i = 0; i < wordNumber - 1; i++)
        {
            words[i] = wordInput[i + 1].transform.Find("Text").GetComponent<Text>().text;
            translations[i] = translationInput[i + 1].transform.Find("Text").GetComponent<Text>().text;
        }
       
        //Only activate play button if every word has been assigned
        if (wordNumber == 0)
        {
            play.SetActive(false);
            load.transform.position = new Vector3(load.transform.position.x, play.transform.GetChild(1).transform.position.y + 440, 0);
            //loadPanel.transform.position = new Vector3(savePanel.transform.position.x, play.transform.position.y, 0);
        }
        else
        {
            play.SetActive(true);
            load.transform.position = new Vector3(load.transform.position.x, play.transform.GetChild(1).transform.position.y + 5, 0);
            loadPanel.transform.position = new Vector3(savePanel.transform.position.x, play.transform.position.y - 350, 0);
        }
        for(int i = 0; i<wordNumber-1; i++)
        {
            if(string.Equals(words[i],"") || string.Equals(translations[i], ""))
            {
                PlayButton.allWords = false;
                savePanel.SetActive(false);
                break;
            }
            if (i == wordNumber - 2)
                PlayButton.allWords = true;
        }
        
        if(wordNumber > 2)
        {
            Debug.Log(wordNumber);
            for (int i = 0; i < wordNumber-2; i++)
            {
                for (int j=1; j<wordNumber-1; j++)
                {
                    Debug.Log("i: " + translations[i] + " j: " + translations[j]);
                    if (translations[i].Equals(translations[j]) && (translations[i] != "" && translations[j] != ""))
                    {
                        makeSure.SetActive(true);
                        play.SetActive(false);
                    }
                    else
                    {
                        makeSure.SetActive(false);
                    }
                }
            }
        }
        
    }
}
