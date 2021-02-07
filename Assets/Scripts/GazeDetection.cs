using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeDetection : MonoBehaviour
{
    Camera cam;
    GameObject activeText;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            if (objectHit.tag.Equals("GazeDetector"))
            {
                //Debug.DrawRay(ray.origin, ray.direction, Color.green, 10000, true);
                if (activeText != null)
                {
                    activeText.SetActive(false);
                }
                
                activeText = objectHit.transform.GetChild(0).gameObject;
                activeText.SetActive(true);
            }
            else
            {
                //Debug.DrawRay(ray.origin, ray.direction, Color.red, 10000, true);
                activeText.SetActive(false);
            }
            
        }
        else
        {
            if (activeText != null)
            {
                activeText.SetActive(false);
            }
            //Debug.DrawRay(ray.origin, ray.direction, Color.white, 10000, true);
        }
    }
}
