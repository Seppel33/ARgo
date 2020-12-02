using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarContentManager : MonoBehaviour
{
    public static bool ShowRealValue;
    // Start is called before the first frame update
    void Start()
    {
        ShowRealValue = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeMode()
    {
        ShowRealValue = !ShowRealValue;
    }
}
