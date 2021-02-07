using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarContentManager : MonoBehaviour
{
    public static bool ShowRealValue;
    
    public static Vector3 PrefabScale;
    public GameObject Sun;
    public static Vector3 relativeSunMovement;
    private Vector3 oldSunPos;
    // Start is called before the first frame update
    void Start()
    {
        ShowRealValue = false;
        
        PrefabScale = transform.parent.transform.localScale;
        oldSunPos = Sun.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateRelSunMove();
    }
    public void ChangeMode()
    {
        PrefabScale = transform.parent.transform.localScale;
        ShowRealValue = !ShowRealValue;
    }
    
    private void CalculateRelSunMove()
    {
        relativeSunMovement = Sun.transform.position - oldSunPos;
        oldSunPos = Sun.transform.position;
    }
}
