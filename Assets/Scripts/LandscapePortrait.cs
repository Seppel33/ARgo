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
                go.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            }
            scaledUI[0].transform.localScale = new Vector3(scaledUI[0].transform.localScale.x * scalefactor, scaledUI[0].transform.localScale.y * scalefactor, 1);
            scaledUI[1].transform.localScale = new Vector3(scaledUI[1].transform.localScale.x * scalefactor * 1.1f, scaledUI[1].transform.localScale.y * scalefactor * 1.1f, 1);
        }
        else if (Screen.orientation == ScreenOrientation.Portrait)
        {
            scaledUI[0].transform.localScale = new Vector3(0.7f, 0.7f, 1);
            scaledUI[1].transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
