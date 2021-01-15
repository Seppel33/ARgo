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
    
    void Start()
    {
        infobox = GameObject.FindWithTag("InfoText").GetComponent<Text>();
        
        infobuttons = GameObject.FindGameObjectsWithTag("Bulb");
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

    public void TurnBulbOff(bool tog)
    {
        if (tog)
        {
            foreach(GameObject go in infobuttons)
            {
                go.SetActive (false);
            }
        }
        else
        {
            foreach(GameObject go in infobuttons)
            {
                go.SetActive (true);
            }
        }
            
    }
}
