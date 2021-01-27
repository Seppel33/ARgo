using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideUnhideTextbox : MonoBehaviour
{
    [SerializeField] private GameObject textBox;

    private Toggle toggleButton;
    private void Start()
    {
        toggleButton = gameObject.GetComponent<Toggle>();
    }

    private void Update()
    {
        
    }

    public void HideTextbox(bool tog)
    {
        //Für den Fall, dass die Textbox vor dem Buttonpress aktiv war
        if (textBox.activeInHierarchy)
        {
            tog = true;
        }
        else
        {
            tog = false;
        }
        
        //Wenn der Toggle true ist, dann soll die Textbox ausgeschaltet werden
        if (tog)
        {
            textBox.SetActive(false);
        }
        else
        {
            textBox.SetActive(true);
        }
    }
}
