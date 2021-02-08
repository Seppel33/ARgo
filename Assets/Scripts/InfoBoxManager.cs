using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Toggle = UnityEngine.UIElements.Toggle;

public class InfoBoxManager : MonoBehaviour
{
    // Infotext, welcher in dem Interface angezeigt werden soll
    [SerializeField] private String infoText;
    
    // Das Interface, welches den Infotext anzeigt
    private Text infobox;
    
    private GameObject infoBoxGameObject;
    
    // AudioSource, welche die Leserstimme abspielt
    private AudioSource infoboxAudioSource;
    
    // 3D-Infobutton, welcher angeklickt wurde
    private GameObject raycastHitObject;
    
    // Audioclipvariable, in welcher der Ton vom Sprecher gespeichert werden soll
    [SerializeField] private AudioClip readAudio;
    
    private GameObject[] arPrefabs;
    
    
    
    void Start()
    {
        // Variablen füllen
        infoBoxGameObject = GameObject.Find("Canvas").transform.GetChild(0).transform.gameObject;
        infoboxAudioSource = GameObject.Find("AudioReadText").GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Wenn der Touchscreen berührt wurde
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            // Soll ein Raycast gemacht werden
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            
            // Trifft der Raycast ein Objekt
            if (Physics.Raycast(ray, out Hit))
            {
                // Welches den Tag "Bulb" hat, also ein InfoButton ist
                if(Hit.transform.tag.Equals("Bulb"))
                {
                    // Und der Bildschirm im Portraitmodus ist
                    if (Screen.orientation == ScreenOrientation.Portrait)
                    {
                        // Soll zunächst die Schaltfläche des Textes eingeblendet werden
                        infoBoxGameObject.transform.GetChild(0).gameObject.SetActive(true);
                        for (int i = 0; i < infoBoxGameObject.transform.GetChild(0).gameObject.transform.childCount; i++)
                        {
                            // Wenn die Kindobjekte nicht aktiv sind
                            if (!infoBoxGameObject.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.activeInHierarchy)
                            {
                                // Sollen sie aktiviert werden
                                infoBoxGameObject.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.SetActive(true);
                            }
                        }
                
                        // Speichert die die Textkomponente der Infobox in einer variable
                        infobox = GameObject.FindWithTag("InfoText").GetComponent<Text>();
                        
                        // Das vom Raycast getroffene Objekt wird in einer Variable gespeichert
                        raycastHitObject = Hit.transform.gameObject;
                        
                        // Der Text vom getroffenen Objekt wird in der Infobox angezeigt (wird im Editor zugewiesen)
                        infobox.text = raycastHitObject.GetComponent<InfoBoxManager>().infoText;
                
                        // Die Audiosource wird ebenfalls mit dem Clip des getroffenen Objektes überschrieben
                        infoboxAudioSource.clip = raycastHitObject.GetComponent<InfoBoxManager>().readAudio;
                        
                        //Der alte Sound gestoppt
                        infoboxAudioSource.Stop();
                        //und der neue abgespielt
                        infoboxAudioSource.Play();
                    }
                    // Für den Fall, dass der Bildschirm in den Landschaftsmodus gedreht wird
                    else if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
                    {
                        
                        //In diesem Fall sollen die Texte nicht angezeigt werden, da im Landschaftsmodus dafür nicht genug platz ist
                        raycastHitObject = Hit.transform.gameObject;

                        infoboxAudioSource.clip = raycastHitObject.GetComponent<InfoBoxManager>().readAudio;
                        infoboxAudioSource.Stop();
                        infoboxAudioSource.Play();
                    }
                }
            }
        }

        // Wenn in den Einstellungen die infobuttons ausgeschaltet wurden
        if (GlobalDataManager.infoButtonsOff && gameObject.transform.tag.Equals("Bulb") && gameObject.activeInHierarchy)
        {
            // Sollen alle sich aktuell in der Szene befindenen Infobuttons deaktiviert werden
            //gameObject.SetActive(false);
            foreach (Transform children in gameObject.transform)
            {
                children.transform.gameObject.SetActive(false);
            }
        }
    }

    public void InfoAudioPlay()
    {
        //Stoppt die Leserstimme, wenn der Junge-Knopf gedrückt wurd und spielt sie dann auch wieder ab
        if (infoboxAudioSource.isPlaying)
        {
            infoboxAudioSource.Stop();
        }
        else
        {
            infoboxAudioSource.Play();
        }
    }
}
