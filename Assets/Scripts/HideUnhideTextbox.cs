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
        //Wenn eine Textbox in der Hierarchie ist soll der Pfeil vom Button sich drehen
        if (textBox.activeInHierarchy)
        {
            _image.sprite = down;
        }
        else
        {
            //Wenn keine Textbox in der Hierarchie ist, soll der Text auch nicht vorgelesen werden
            _image.sprite = up;
            readText.Stop();
        }
        
        //Wenn die Buchseite gewechselt wird soll der Leser auch aufhören vorzulesen und die Textbox ausgeschaltet werden, damit alte Inhalte nicht auf einer neuen Seite sind
        if (GlobalDataManager.onPageChanged)
        {
            readText.Stop();
            textBox.SetActive(false);
            GlobalDataManager.onPageChanged = false;
        }
    }

    public void Hide()
    {
        //Versteckt die Textbox, wenn man den Button drückt
        if (textBox.activeInHierarchy)
        {
            textBox.SetActive(false);
        }
        else
        {
            textBox.SetActive(true);
        }
    }
}
