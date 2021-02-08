﻿using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScripts : MonoBehaviour
{
    private AudioSource _audioSource;
    public GameObject[] _infobuttons;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject[] settingsToggle;
    [SerializeField] private GameObject[] tutorials;
    [SerializeField] private GameObject tutorialToggle;
    [SerializeField] private GameObject scanPage;

    private bool switcher = true;
    private void Update()
    {
        if (switcher && GlobalDataManager.firstImageTracked)
        {
            scanPage.SetActive(false);
            switcher = false;
        }
        
        //Debug.Log(GlobalDataManager.infoButtonsOff);
        /*if (GlobalDataManager.infoButtonsOff)
        {
            foreach(GameObject go in _infobuttons)
            {
                //go.transform.GetChild(0).gameObject.SetActive(false);
                foreach (Transform children in go.transform)
                {
                    if (children.transform.gameObject.activeInHierarchy)
                    {
                        children.transform.gameObject.SetActive(false);
                    }
                }
            }
        }*/
    }

    public void TurnBulbOff(bool tog)
    {
        _infobuttons = GameObject.FindGameObjectsWithTag("Bulb");
        if (tog)
        {
            GlobalDataManager.infoButtonsOff = true;
            foreach(GameObject go in _infobuttons)
            {
                //go.transform.GetChild(0).gameObject.SetActive(false);
                foreach (Transform children in go.transform)
                {
                    children.transform.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            GlobalDataManager.infoButtonsOff = false;
            foreach(GameObject go in _infobuttons)
            {
                //go.transform.GetChild(0).gameObject.SetActive(true);
                foreach (Transform children in go.transform)
                {
                    children.transform.gameObject.SetActive(true);
                }
            }
        }
    }
    
    public void AmbienceOff(bool tog)
    {
        _audioSource = GameObject.FindWithTag("ARPrefab").GetComponent<AudioSource>();

        if (tog && GlobalDataManager.ambienceIsPlaying)
        {
            _audioSource.Stop();
            GlobalDataManager.ambienceIsPlaying = false;
        }
        else
        {
            _audioSource.Play();
            GlobalDataManager.ambienceIsPlaying = true;
        } 
    }

    public void TutorialOff(bool tog)
    {
        if (tog)
        {
            foreach (GameObject go in tutorials)
            {
                go.SetActive(true);
                if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
                {
                    if (go.name.Equals("IasonTutorial"))
                    {
                        go.SetActive(false);
                    }
                }
            }
        }
        else if (!tog)
        {
            foreach (GameObject go in tutorials)
            {
                go.SetActive(false);
            }
        }
    }
    
    public void MenuOpenClose(bool tog)
    {
        if (tog)
        {
            foreach (GameObject go in settingsToggle)
            {
                go.SetActive(true);
            }
        }
        else if (!tog)
        {
            foreach (GameObject go in settingsToggle)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in tutorials)
            {
                go.SetActive(false);
            }
        }

        if (!tutorialToggle.activeInHierarchy)
        {
            tutorialToggle.GetComponent<Toggle>().isOn = false;
        }
    }
}
