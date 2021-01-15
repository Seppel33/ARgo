using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarContentManager : MonoBehaviour
{
    public static bool ShowRealValue;
    public static bool PauseSim;
    public static Vector3 PrefabScale;
    public GameObject Sun;
    public static Vector3 relativeSunMovement;
    private Vector3 oldSunPos;
    // Start is called before the first frame update
    void Start()
    {
        ShowRealValue = false;
        PauseSim = false;
        PrefabScale = transform.parent.transform.localScale;
        oldSunPos = Sun.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        calculateRelSunMove();
    }
    public void ChangeMode()
    {
        PrefabScale = transform.parent.transform.localScale;
        ShowRealValue = !ShowRealValue;
    }
    public void PauseScene()
    {
        PauseSim = !PauseSim;
    }
    private void calculateRelSunMove()
    {
        relativeSunMovement = Sun.transform.position - oldSunPos;
        oldSunPos = Sun.transform.position;
    }
}
