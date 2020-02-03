using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GenerateBoard : MonoBehaviour
{
    public char[,] gameBoard;
    private char[,] filledSpaces;
    public static GameObject[] tiles;
    public GameObject tile;
    public static int[,] tileNumber;
    public static int wordCount;
    private static int numberOfWords = 10;
    private int wordNumber = 1;
    private int tilePos;
    private string[] wordList;
    private string[] hintWordList;
    public static string[] placedWords;
    public static string[] hintWords;
    private string loadGameBoard;
    private string loadHints;
    private Dictionary<string, int[]> map;
    private Dictionary<string, int> tileNumberToTile;
    //public float targetTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Refresh the cache
        gameBoard = new char[100, 100];
        filledSpaces = new char[100, 100];
        tiles = new GameObject[10000];
        tileNumber = new int[10000, 2];
        wordCount = 0;
        tilePos = 0;
        wordList = new string[2000];
        hintWordList = new string[2000];
        map = new Dictionary<string, int[]>();
        tileNumberToTile = new Dictionary<string, int>();

        if (!Menu.customGame)
        {
            if(Menu.challenge == "Top100Words")
            {
                loadGameBoard = Menu.challenge + "/" + Menu.puzzleLanguage;
                loadHints = Menu.challenge + "/" + Menu.puzzleLanguage + "_" + Menu.hintLanguage;
            }
            else
            {
                loadGameBoard = Menu.challenge + "/" + Menu.puzzleLanguage;
                loadHints = Menu.challenge + "/" + Menu.hintLanguage;
            }
            
            WordsToArray();
            PickWords();
        }
        else
        {
            SetupCustomGame();
        }
        tile.SetActive(false);
    }

    // Update is called once per frame`
    void Update()
    {
        //targetTime += Time.deltaTime;
    }

    //Select and sort custom words
    private void SetupCustomGame()
    {
        //Calculate wordnumber
        int wordNumber = 0;

        for (int i = 0; i < CustomTiles.words.Length; i++)
        {
            if (CustomTiles.words[i] != null)
            {
                Debug.Log(CustomTiles.words[i]);
                wordNumber++;
            }
            else
                break;
        }
        Quick_Sort(CustomTiles.words, CustomTiles.translations, 0, wordNumber - 1);
        placedWords = new string[wordNumber];
        hintWords = new string[wordNumber];
        string[] placedCantFit = new string[wordNumber];
        string[] hintCantFit = new string[wordNumber];
        string[] placeHolder = new string[wordNumber - 1];
        int[] locations = new int[wordNumber];
        int cantFit = 0;

        for (int i = 0; i < wordNumber; i++)
        {
            if (!CompareLetters(placedWords, CustomTiles.words[i]))
            {
                placedCantFit[cantFit] = CustomTiles.words[i];
                hintCantFit[cantFit] = CustomTiles.translations[i];
                cantFit++;
                for (int j = 0; j < i; j++)
                    placeHolder[j] = placedWords[j];
                placedWords = placeHolder;
                placeHolder = new string[placedWords.Length - 1];
            }
            else
            {
                placedWords[i] = CustomTiles.words[i];
                hintWords[i] = CustomTiles.translations[i];
            }
        }
        
        //Place words that didn't intersect with others on their own
        int x = 50;
        int y = 45;
        int length;
        for (int i = 0; i<cantFit; i++)
        {
            string placed = placedCantFit[i];
            length = placedCantFit[i].Length;
            //Scan gameboard to see where word can fit
            int xLoc = 0;
            int yLoc = 0;
            int combo = 0;
            for (int k = y; y > 0; y--)
            {
                for (int j = x; j < 100; j++)
                {
                    if (gameBoard[j, y] == 0)
                        combo++;
                    else
                        combo = 0;
                    if (combo == length)
                    {
                        xLoc = j;
                        yLoc = k;
                        goto end;
                    }
                }
            }
            end:
            //Add word to gameBoard
            for(int m = 0; m < length; m++)
            {
                gameBoard[xLoc + m, yLoc] = placed[m];
            }
            //Generate tiles for word
            int[,] input = new int[length, 2];
            for (int n = 0; i < length; i++)
            {
                input[i, 0] = xLoc + n;
                input[i, 1] = yLoc;
            }
            GenerateTiles(true, input);
        }
        
    }

    //Sorting algorithm
    private void Quick_Sort(string[] arr1, string[] arr2, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr1, arr2, left, right);
            if (pivot > 1)
            {
                Quick_Sort(arr1, arr2, left, pivot - 1);
            }
            if (pivot + 1 < right)
            {
                Quick_Sort(arr1, arr2, pivot + 1, right);
            }
        }

    }

    //Called by quicksort
    private static int Partition(string[] arr1, string[] arr2, int left, int right)
    {
        string pivot = arr1[left];
        int n = 0;
        while (true)
        {
            n++;
            while (arr1[left].Length < pivot.Length)
            {
                left++;
            }
            while (arr1[right].Length > pivot.Length)
            {
                right--;
            }
            if (left < right)
            {
                if (arr1[left].Length == arr1[right].Length) return right;

                string temp = arr1[left];
                arr1[left] = arr1[right];
                arr1[right] = temp;
                temp = arr2[left];
                arr2[left] = arr2[right];
                arr2[right] = temp;
            }
            else
            {
                return right;
            }
        }
    }

    //Read text file of words, tranform into array
    private void WordsToArray()
    {
        //Read gameboard words
        Debug.Log("loadGameBoard:" + loadGameBoard);
        string text = (Resources.Load(loadGameBoard, typeof(TextAsset)) as TextAsset).ToString();
        var words = text.Split('\n');
        int i = 0;
        foreach (var word in words)
        {
            wordList[i] = word;
            i++;
        }

        //Read hint words
        text = (Resources.Load(loadHints, typeof(TextAsset)) as TextAsset).ToString();
        words = text.Split('\n');
        i = 0;
        foreach (var word in words)
        {
            hintWordList[i] = word;
            i++;
        }
    }

    //Choose and place words to use for particular puzzle
    private void PickWords()
    {
        string word;
        string hintWord;
        int randomWord;
        placedWords = new string[10];
        hintWords = new string[10];
        //Select 10 random words from wordList
        int count = 0;                          //Stop program at a certain point so it doesn't endlessly loop
        for (int i = 0; i < 10; i++)
        {
            if (count++ == 100000)
                break;
            //Different sized arrays for different challenges
            if (Menu.challenge == "Top100Words")
                randomWord = Random.Range(0, 996);
            else if (Menu.challenge == "Sports")
                randomWord = Random.Range(0, 90);
            else if (Menu.challenge == "Animals")
                randomWord = Random.Range(0, 77);
            else if (Menu.challenge == "Food")
                randomWord = Random.Range(0, 110);
            else
                randomWord = Random.Range(0, 72);

            word = wordList[randomWord];
            if (Menu.puzzleLanguage == "Russian" || Menu.puzzleLanguage == "Spanish") // fix glitch where russian and spanish tiles have 1 too many letters
                word = word.Substring(0, word.Length - 2);
            Debug.Log(word);
            hintWord = hintWordList[randomWord];

            if (i == 0)
            {
                if (CompareLetters(placedWords, word))   //Place first word on gameboard
                {
                    placedWords[i] = word;
                    hintWords[i] = hintWord;
                    continue;
                }
                i--;
            }

            //Check if word has already been picked
            bool alreadyPlaced = false;
            for (int j = 0; j < i; j++)
            {
                if (string.Equals(placedWords[j], word))
                    alreadyPlaced = true;
            }

            ////Check if word can be placed on board and place it if it can
            if (!alreadyPlaced && CompareLetters(placedWords, word))
            {
                Debug.Log(i);
                placedWords[i] = word;
                hintWords[i] = hintWord;
            }
            else// if (targetTime < 10.0f)
            {
                i--;
            }
        }
        for (int i = 0; i < 10; i++)
            Debug.Log(placedWords[i]);
        for (int i = 0; i < 10; i++)
            Debug.Log(hintWords[i]);
    }

    //Find areas for words to intersect eachother
    private bool CompareLetters(string[] array, string newWord)
    {
        //Place first word
        if (array[0] == null && newWord != null)
            if (AddToBoard(null, newWord, null))
                return true;

        //Check if and where new word has a shared letter with a word in array
        int[] intersectionPoint = new int[2]; //newWord,word
        foreach (string word in array)
        {
            if (word == null)
                return false;

            for (int i = 0; i < newWord.Length; i++)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    if (newWord[i] == word[j])
                    {
                        intersectionPoint[0] = i;
                        intersectionPoint[1] = j;
                        if (AddToBoard(word, newWord, intersectionPoint))
                            return true;
                    }
                }
            }
        }
        return false;
    }

    //Add newWord to gameboard at intersectionPoint
    private bool AddToBoard(string word, string newWord, int[] intersectionPoint)
    {
        int[] newWordLocation = new int[3];
        int[,] input = new int[newWord.Length, 2];
        //Place first word
        if (word == null && intersectionPoint == null)
        {
            int x = 50;
            int y = 50;
            for (int i = 0; i < newWord.Length; i++)
            {
                gameBoard[x + i, y] = newWord[i];
            }
            newWordLocation[0] = x;
            newWordLocation[1] = y;
            newWordLocation[2] = 0;
            map.Add(newWord, newWordLocation);
            for (int i = 0; i < newWord.Length; i++)
            {
                input[i, 0] = x + i;
                input[i, 1] = y;
            }
            GenerateTiles(true, input);
            wordNumber++;
            return true;
        }
        int[] wordLocation = map[word];

        //Scan horizontal word to see if newWord fits
        if (wordLocation[2] == 0)
        {
            int x = wordLocation[0] + intersectionPoint[1];
            int y = wordLocation[1];
            //Scan down
            for (int i = 1; i <= (newWord.Length - intersectionPoint[0]); i++)
            {
                if (gameBoard[x, y + i] != 0)
                    return false;
                //check sides
                if (gameBoard[x + 1, y + i] != 0)
                    return false;
                if (gameBoard[x - 1, y + i] != 0)
                    return false;
            }
            //Scan up
            for (int i = 1; i <= intersectionPoint[0] + 1; i++)
            {
                if (gameBoard[x, y - i] != 0)
                    return false;
                //check sides
                if (gameBoard[x + 1, y - i] != 0)
                    return false;
                if (gameBoard[x - 1, y - i] != 0)
                    return false;
            }
            //Insert word
            newWordLocation[0] = x;
            newWordLocation[1] = y - intersectionPoint[0];
            newWordLocation[2] = 1;
            int k = newWordLocation[1];

            for (int j = 0; j < newWord.Length; j++)
            {
                gameBoard[x, k] = newWord[j];
                k++;
            }
            map.Add(newWord, newWordLocation);
            for (int i = 0; i < newWord.Length; i++)
            {
                input[i, 0] = x;
                input[i, 1] = y - intersectionPoint[0] + i;
            }
            GenerateTiles(false, input);
            wordNumber++;
            return true;
        }
        //Scan vertical word to see if newWord fits
        else if (wordLocation[2] == 1)
        {
            int x = wordLocation[0];
            int y = wordLocation[1] + intersectionPoint[1];
            //Scan right
            for (int i = 1; i <= newWord.Length - intersectionPoint[0]; i++)
            {
                if (gameBoard[x + i, y] != 0)
                    return false;
                //check over and under
                if (gameBoard[x + i, y + 1] != 0)
                    return false;
                if (gameBoard[x + i, y - 1] != 0)
                    return false;
            }
            //Scan left
            for (int i = 1; i <= intersectionPoint[0] + 1; i++)
            {
                if (gameBoard[x - i, y] != 0)
                    return false;
                //check over and under
                if (gameBoard[x - i, y + 1] != 0)
                    return false;
                if (gameBoard[x - i, y - 1] != 0)
                    return false;
            }

            //Insert word
            newWordLocation[0] = x - intersectionPoint[0];
            newWordLocation[1] = y;
            newWordLocation[2] = 0;
            int k = newWordLocation[0];

            for (int j = 0; j < newWord.Length; j++)
            {
                gameBoard[k, y] = newWord[j];
                k++;
            }
            map.Add(newWord, newWordLocation);
            for (int i = 0; i < newWord.Length; i++)
            {
                input[i, 0] = x - intersectionPoint[0] + i;
                input[i, 1] = y;
            }
            GenerateTiles(true, input);
            wordNumber++;
            return true;
        }
        return false;
    }

    //Generate from gameBoard
    private void GenerateTiles(bool horizontal, int[,] input)
    {
        //Instantiate tiles
        Vector3 vector = new Vector3(-49.8f / 2, 53.0f / 2, 0.0f);
        int a = 0;
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                vector += new Vector3(.5f, 0f, 0f);
                //return when all tiles have been scanned over
                if (a == input.GetLength(0))
                {
                    wordCount++;
                    return;
                }

                if (j == input[a, 0] && i == input[a, 1])
                {
                    a++;
                    //Use map to backtrack to previously used horizontal tiles, and add a vertical wordNumber, or vice-versa 
                    int[] x = { j, i };
                    string y = x[0].ToString() + x[1].ToString();
                    if (!tileNumberToTile.ContainsKey(y))
                        tileNumberToTile.Add(y, tilePos);
                    //Create tiles for newest word
                    if (filledSpaces[j, i] != '$')    //Don't create tiles ontop of other tiles
                    {
                        GameObject newTile = Instantiate(tile, vector, Quaternion.identity);
                        tiles[tilePos] = newTile;
                        tiles[tilePos].GetComponentInChildren<Text>().text = gameBoard[j, i] + "";
                        Text text = tiles[tilePos].GetComponentInChildren<Text>();
                        if (!text || text.text.Length < 1 || text == null || text.text == "" || text.text == null || text.text == " " || text.text == "\t" || text.text == "\n")
                        {
                            Renderer rend = newTile.GetComponent<Renderer>();
                            rend.material.SetColor("_Color", Color.black);
                        }
                        text.enabled = false;
                        filledSpaces[j, i] = '$';
                        tilePos++;
                    }
                    //Assign a number to each tile depending on the word it contains (for grouping tiles together in OnClick method)
                    if (horizontal)
                    {
                        tileNumber[tileNumberToTile[y], 0] = wordNumber;
                    }
                    else
                    {
                        tileNumber[tileNumberToTile[y], 1] = wordNumber;
                    }
                }
            }
            vector += new Vector3(-50f, -0.5f, 0);
        }
    }
}