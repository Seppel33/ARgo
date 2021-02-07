using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalDataManager : MonoBehaviour
{
    public static bool PauseSim;

    public static bool ambienceIsPlaying;
    // Start is called before the first frame update
    void Start()
    {
        PauseSim = false;
        ambienceIsPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseScene()
    {
        PauseSim = !PauseSim;
    }
}
