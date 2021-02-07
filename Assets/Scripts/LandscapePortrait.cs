using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapePortrait : MonoBehaviour
{
    private GameObject infoBoxGameObject;
    [SerializeField] private GameObject[] scaledUI;
    [SerializeField] private float scalefactor;

    void Start()
    {
        infoBoxGameObject = GameObject.Find("TextboxLOGroup");
    }

    void Update()
    {
        if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            infoBoxGameObject.transform.GetChild(0).gameObject.SetActive(false);
            
            foreach (GameObject go in scaledUI)
            {
                go.transform.localScale = new Vector3(0.35f, 0.35f, 1);
            }

        }
        else if (Screen.orientation == ScreenOrientation.Portrait)
        {
            foreach (GameObject go in scaledUI)
            {
                go.transform.localScale = new Vector3(0.7f, 0.7f, 1);
            }
        }
    }
}
