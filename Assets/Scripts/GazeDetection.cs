using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeDetection : MonoBehaviour
{
    Camera cam; //Main Camera
    GameObject activeText; //Text neben dem Sternenbild

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        //Raycast von Mittelpunkt der Kamera ausgehend
        RaycastHit hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            //Wenn der Ray ein Objekt mit dem Tag "GazeDetector" getroffen hat (Collider)
            if (objectHit.tag.Equals("GazeDetector"))
            {
                //Debug.DrawRay(ray.origin, ray.direction, Color.green, 10000, true);

                //Setze alten Text auf unsichtbar
                if (activeText != null)
                {
                    activeText.SetActive(false);
                }
                
                //Setze neuen Text auf sichtbar
                activeText = objectHit.transform.GetChild(0).gameObject;
                activeText.SetActive(true);
            }
            else
            {
                //Debug.DrawRay(ray.origin, ray.direction, Color.red, 10000, true);
                //Wenn etwas getroffen ohne den passenden Tag
                //Setze aktuellen Text auf unsichtbar
                activeText.SetActive(false);
            }
            
        }
        else
        {
            //Wenn nichts getroffen
            if (activeText != null)
            {
                activeText.SetActive(false);
            }
            //Debug.DrawRay(ray.origin, ray.direction, Color.white, 10000, true);
        }
    }
}
