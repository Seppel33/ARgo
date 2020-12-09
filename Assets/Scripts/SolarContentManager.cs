using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarContentManager : MonoBehaviour
{
    public static bool ShowRealValue;
    public static Vector3 PrefabScale;
    // Start is called before the first frame update
    void Start()
    {
        ShowRealValue = false;
        PrefabScale = transform.parent.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeMode()
    {
        PrefabScale = transform.parent.transform.localScale;
        ShowRealValue = !ShowRealValue;
    }
}
