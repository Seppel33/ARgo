using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScripts : MonoBehaviour
{
    private AudioSource _audioSource;
    private GameObject[] _infobuttons;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject[] settingsToggle;
    [SerializeField] private GameObject[] tutorials;
    [SerializeField] private GameObject tutorialToggle;


    public void TurnBulbOff(bool tog)
    {
        _infobuttons = GameObject.FindGameObjectsWithTag("Bulb");
        if (tog)
        {
            foreach(GameObject go in _infobuttons)
            {
                go.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else
        {
            foreach(GameObject go in _infobuttons)
            {
                go.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
    
    public void AmbienceOff(bool tog)
    {
        _audioSource = GameObject.FindWithTag("ARPrefab").GetComponent<AudioSource>();

        if (tog && _audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
        else
        {
            _audioSource.Play();
        } 
    }

    public void TutorialOff(bool tog)
    {
        if (tog)
        {
            foreach (GameObject go in tutorials)
            {
                go.SetActive(true);
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
