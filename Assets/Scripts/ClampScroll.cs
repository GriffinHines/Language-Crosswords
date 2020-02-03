using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampScroll : MonoBehaviour
{
    private static Vector2 location;
    // Start is called before the first frame update
    void Start()
    {
        location = GameObject.Find("ScrollCanvas").GetComponent<RectTransform>().anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 x = GameObject.Find("ScrollCanvas").GetComponent<RectTransform>().anchoredPosition;
        if (CustomTiles.wordNumber < 4)
            GameObject.Find("ScrollCanvas").GetComponent<RectTransform>().anchoredPosition = new Vector3(location.x, location.y);
        else if (x.y < location.y -2100f)
            GameObject.Find("ScrollCanvas").GetComponent<RectTransform>().anchoredPosition = new Vector3(location.x, location.y - 1800f, 0);
        else if (x.y > location.y + CustomTiles.wordNumber*150)
            GameObject.Find("ScrollCanvas").GetComponent<RectTransform>().anchoredPosition = new Vector3(location.x, location.y + CustomTiles.wordNumber * 10 + CustomTiles.wordNumber * 125, 0);
    }
}
