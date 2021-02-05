using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Toggle = UnityEngine.UIElements.Toggle;

public class Texts : MonoBehaviour
{
    [SerializeField] private String infoText;
    
    private Text infobox;
    private GameObject infoBoxGameObject;
    private AudioSource infoboxAudioSource;
    private GameObject raycastHitObject;
    [SerializeField] private AudioClip readAudio;
    
    private GameObject[] infobuttons;
    private GameObject[] arPrefabs;
    
    
    
    void Start()
    {
        infoBoxGameObject = GameObject.Find("Canvas").transform.GetChild(0).transform.gameObject;
        infoboxAudioSource = GameObject.Find("AudioReadText").GetComponent<AudioSource>();
    }

    private void Update()
    {
        //Debug.Log(infoBoxGameObject.transform.GetChild(0).gameObject.transform.childCount);
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                //Am besten, wenn man hiden und showen kann wann man will.
                infoBoxGameObject.transform.GetChild(0).gameObject.SetActive(true);
                for (int i = 0; i < infoBoxGameObject.transform.GetChild(0).gameObject.transform.childCount; i++)
                {
                    if (!infoBoxGameObject.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.activeInHierarchy)
                    {
                        infoBoxGameObject.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.SetActive(true);
                    }
                }
                
                infobox = GameObject.FindWithTag("InfoText").GetComponent<Text>();
                raycastHitObject = Hit.transform.gameObject;
                //DisplayText(Hit.transform.gameObject.GetComponent<Texts>().infoText);
                infobox.text = raycastHitObject.GetComponent<Texts>().infoText;
                
                //infoboxAudio = gameObject.GetComponent<AudioSource>();
                infoboxAudioSource.clip = raycastHitObject.GetComponent<Texts>().readAudio;
                infoboxAudioSource.Stop();
                infoboxAudioSource.Play();
            }
        }
    }

    public void DisplayText(String txt)
    {
        //InfoText anzeigen
        infobox.text = txt;
        
        //AudioInfobox Abspielen
        //infoboxAudio.Stop();
        //infoboxAudio.Play();
    }

    public void InfoAudioPlay()
    {
        if (infoboxAudioSource.isPlaying)
        {
            infoboxAudioSource.Stop();
        }
        else
        {
            infoboxAudioSource.Play();
        }
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
