using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static bool customGame;
    public static string challenge;
    public static string puzzleLanguage;
    public static string hintLanguage;
    public Dropdown translate;
    public Dropdown translateTo;
    private static GameObject bottom;
    private static GameObject top100Check;
    private static GameObject sportsCheck;
    private static GameObject animalsCheck;
    private static GameObject foodCheck;
    private static GameObject artCheck;
    public GameObject description;

    void Start()
    {
        if(bottom = GameObject.Find("Bottom"))
            bottom.SetActive(false);
        if(top100Check = GameObject.Find("Top100Check"))
            top100Check.SetActive(false);
        if(sportsCheck = GameObject.Find("SportsCheck"))
            sportsCheck.SetActive(false);
        if (animalsCheck = GameObject.Find("AnimalsCheck"))
            animalsCheck.SetActive(false);
        if (foodCheck = GameObject.Find("FoodCheck"))
            foodCheck.SetActive(false);
        if (artCheck = GameObject.Find("ArtCheck"))
            artCheck.SetActive(false);
    }
    public void Challenges()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void Custom()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void Options()
    {
        SceneManager.LoadScene(5, LoadSceneMode.Single);
    }

    public void ReverseButton()
    {
        if (translate.value != 0 && translateTo.value != 0)
        {
            int x = translate.value;
            translate.value = translateTo.value;
            translateTo.value = x;
        }
    }

    public void TranslateDropdown()
    {
        switch (translate.value)
        {
            case 1:
                hintLanguage = "English";
                break;
            case 2:
                hintLanguage = "Spanish";
                break;
            case 3:
                hintLanguage = "French";
                break;
            case 4:
                hintLanguage = "Russian";
                break;
            case 5:
                hintLanguage = "Zulu";
                break;
        }
    }

    public void ToDropdown()
    {
        switch (translateTo.value)
        {
            case 1:
                puzzleLanguage = "English";
                break;
            case 2:
                puzzleLanguage = "Spanish";
                break;
            case 3:
                puzzleLanguage = "French";
                break;
            case 4:
                puzzleLanguage = "Russian";
                break;
            case 5:
                puzzleLanguage = "Zulu";
                break;
        }
    }

    public void Top100Words()
    {
        challenge = "Top100Words";
        bottom.SetActive(true);
        top100Check.SetActive(true);
        sportsCheck.SetActive(false);
        animalsCheck.SetActive(false);
        foodCheck.SetActive(false);
        artCheck.SetActive(false);
        description.SetActive(true);
    }

    public void Sports()
    {
        challenge = "Sports";
        bottom.SetActive(true);
        sportsCheck.SetActive(true);
        top100Check.SetActive(false);
        animalsCheck.SetActive(false);
        foodCheck.SetActive(false);
        artCheck.SetActive(false);
        description.SetActive(false);
    }

    public void Animals()
    {
        challenge = "Animals";
        bottom.SetActive(true);
        animalsCheck.SetActive(true);
        top100Check.SetActive(false);
        sportsCheck.SetActive(false);
        foodCheck.SetActive(false);
        artCheck.SetActive(false);
        description.SetActive(false);
    }

    public void Food()
    {
        challenge = "Food";
        bottom.SetActive(true);
        top100Check.SetActive(false);
        sportsCheck.SetActive(false);
        animalsCheck.SetActive(false);
        description.SetActive(false);
        artCheck.SetActive(false);
        foodCheck.SetActive(true);
    }

    public void Art()
    {
        challenge = "Art";
        bottom.SetActive(true);
        top100Check.SetActive(false);
        sportsCheck.SetActive(false);
        animalsCheck.SetActive(false);
        description.SetActive(false);
        foodCheck.SetActive(false);
        artCheck.SetActive(true);
    }

    public void PlayChallenge()
    {
        customGame = false;
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }

    public void PlayCustomGame()
    {
        customGame = true;
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }

    public void OpenSave()
    {
        CustomTiles.loadPanel.SetActive(false);
        CustomTiles.savePanel.SetActive(true);
    }

    public void OpenLoad()
    {
        CustomTiles.loadPanel.SetActive(true);
        CustomTiles.savePanel.SetActive(false);
    }

    public void Save()
    {
        //Make sure savefile has name
        string saveName = GameObject.Find("SaveAsText").GetComponent<Text>().text;
        if (!string.Equals(saveName, ""))
        {
            //Set save number
            int n;
            if (PlayerPrefs.HasKey("saveNumber"))
                n = PlayerPrefs.GetInt("saveNumber");
            else
                n = 0;
            PlayerPrefs.SetInt("saveNumber", ++n);

            //Save arrays into PlayerPrefsX
            string[] words = new string[CustomTiles.wordNumber-1];
            string[] translations = new string[CustomTiles.wordNumber-1];
            for(int i = 0; i<CustomTiles.wordNumber-1; i++)
            {
                words[i] = CustomTiles.words[i];
                translations[i] = CustomTiles.translations[i];
            }
            PlayerPrefsX.SetStringArray("WordsSave" + n, words);
            PlayerPrefsX.SetStringArray("TranslationsSave" + n, translations);
            PlayerPrefs.SetString("SaveName" + n, saveName);
            CustomTiles.savePanel.SetActive(false);
            SceneManager.LoadScene(3, LoadSceneMode.Single);
        }
    }

    public void Load()
    {
        //Find load number
        int n;
        if (PlayerPrefs.HasKey("saveNumber"))
            n = PlayerPrefs.GetInt("saveNumber");
        else
            n = 0;

        //Load selected game
        Dropdown x = GameObject.Find("LoadDropdown").GetComponent<Dropdown>();
        if(x.value+1 > n)
            return;
        CustomTiles.loading = true; //Make sure CustomTiles update() function doesn't overwrite words and translations
        CustomTiles.words = PlayerPrefsX.GetStringArray("WordsSave" + (x.value + 1));
        CustomTiles.translations = PlayerPrefsX.GetStringArray("TranslationsSave" + (x.value + 1));
        PlayCustomGame();
    }

    public void CancelLoadSave()
    {
        CustomTiles.savePanel.SetActive(false);
        CustomTiles.loadPanel.SetActive(false);
    }

    public void Back()
    {
        customGame = false;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void ClampValue()
    {
        GameObject.Find("ScrollCanvas").GetComponent<RectTransform>().anchoredPosition = new Vector3(394.5f, -1746.834f, 0);
    }

    public void QuitButton()
    {
        QuitPanel.quitPanel.SetActive(true);
    }

    public void CancelQuitGame()
    {
        QuitPanel.quitPanel.SetActive(false);
    }

    public void CenterCamera()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(0, 1, -10);
    }
}
