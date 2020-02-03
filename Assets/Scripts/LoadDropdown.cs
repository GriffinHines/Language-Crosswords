using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadDropdown : MonoBehaviour
{
    public static Dropdown dropdown;
    public GameObject loadPanel;
    // Start is called before the first frame update
    public void Start()
    {
        loadPanel = GameObject.Find("LoadPanel");
        loadPanel.SetActive(false);
        dropdown = GetComponent<Dropdown>();
        FillDropdown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void FillDropdown()
    {
        dropdown.ClearOptions();
        List<string> m_DropOptions = new List<string>();
        int n = 0;
        if (PlayerPrefs.HasKey("saveNumber"))
            n = PlayerPrefs.GetInt("saveNumber");
        else
        {
            m_DropOptions.Add("Empty");
            m_DropOptions.Add("Empty");
            m_DropOptions.Add("Empty");
            dropdown.AddOptions(m_DropOptions);
            return;
        }
        string input;
        for (int i = 0; i < n; i++)
        {
            input = PlayerPrefs.GetString("SaveName" + (i + 1));
            m_DropOptions.Add(input);
        }
        dropdown.AddOptions(m_DropOptions);
    }
}
