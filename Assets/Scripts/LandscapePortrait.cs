using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapePortrait : MonoBehaviour
{
    private GameObject infoBoxGameObject;

    void Start()
    {
        infoBoxGameObject = GameObject.Find("TextboxLOGroup");
    }

    void Update()
    {
        if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            infoBoxGameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (Screen.orientation == ScreenOrientation.Portrait)
        {
            infoBoxGameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
