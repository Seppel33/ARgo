using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Texts : MonoBehaviour
{
    [SerializeField] private String[] infoText;

    [SerializeField] private int index;

    private Text infobox;
    
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
        //TurnBulbOff();
    }

    public void DisplayText()
    {
        infobox.text = infoText[index];
    }

    public void TurnBulbOff()
    {
        GameObject.FindWithTag("Bulb").SetActive(false);
    }
}
