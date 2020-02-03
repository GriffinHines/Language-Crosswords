using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitPanel : MonoBehaviour
{
    public static GameObject quitPanel;
    // Start is called before the first frame update
    void Start()
    {
        quitPanel = GameObject.Find("QuitPanel");
        quitPanel.SetActive(false);
    }
}
