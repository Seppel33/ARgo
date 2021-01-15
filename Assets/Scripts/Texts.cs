using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Toggle = UnityEngine.UIElements.Toggle;

public class Texts : MonoBehaviour
{
    [SerializeField] private String[] infoText;

    [SerializeField] private int index;

    private Text infobox;
    private int infobuttonCount;
    private GameObject[] infobuttons;
    private GameObject[] arPrefabs;
    
    
    void Start()
    {
        infobox = GameObject.FindWithTag("InfoText").GetComponent<Text>();
        
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                DisplayText();
            }
        }
    }

    public void DisplayText()
    {
        infobox.text = infoText[index];
    }

    //In eigene Klasse
    public void TurnBulbOff(bool tog)
    {
        infobuttons = GameObject.FindGameObjectsWithTag("Bulb");
        if (tog)
        {
            foreach(GameObject go in infobuttons)
            {
                go.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else
        {
            foreach(GameObject go in infobuttons)
            {
                go.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    //In eigene Klasse
    public void SoundOnOff(bool tog)
    {
        arPrefabs = GameObject.FindGameObjectsWithTag("ARPrefab");
        if (tog)
        {
            foreach (GameObject go in arPrefabs)
            {
                go.GetComponent<AudioSource>().Pause();
            }
        }
        else
        {
            foreach (GameObject go in arPrefabs)
            {
                go.GetComponent<AudioSource>().UnPause();
            }
        }
    }

    public void Tutorial(bool tog)
    {
        
    }
}
