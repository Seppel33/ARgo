using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarScale : MonoBehaviour
{
    public static bool ShowRealValue;
    public static Vector3 PrefabScale;
    public SolarContentManager solarContentManager;


    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                if(Hit.transform.name.Equals("massstab")){
                    solarContentManager.ChangeMode();
                }
            }
        }
        
    }
}
