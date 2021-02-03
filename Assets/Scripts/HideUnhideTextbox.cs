using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideUnhideTextbox : MonoBehaviour
{
    [SerializeField] private GameObject textBox;

    private Image _image;
    [SerializeField] private Sprite down;
    [SerializeField] private Sprite up;
    [SerializeField] private AudioSource readText;


    private void Start()
    {
        _image = gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        if (textBox.activeInHierarchy)
        {
            _image.sprite = down;
        }
        else
        {
            _image.sprite = up;
            readText.Stop();
        }
    }

    public void Hide()
    {
        if (textBox.activeInHierarchy)
        {
            textBox.SetActive(false);
        }
        else
        {
            textBox.SetActive(true);
        }
    }
    public void HideTextbox(bool tog)
    {
        //Für den Fall, dass die Textbox vor dem Buttonpress aktiv war
        /*if (textBox.activeInHierarchy)
        {
            tog = true;
        }
        else
        {
            tog = false;
        }*/
        
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
