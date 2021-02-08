using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalDataManager : MonoBehaviour
{
    public static bool PauseSim;

    public static bool ambienceIsPlaying;

    public static bool firstImageTracked;

    public static bool onPageChanged;
    // Start is called before the first frame update
    void Start()
    {
        onPageChanged = false;
        PauseSim = false;
        ambienceIsPlaying = true;
        firstImageTracked = false;
    }
    
    public void PauseScene()
    {
        PauseSim = !PauseSim;
    }
}
