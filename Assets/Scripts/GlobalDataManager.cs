using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalDataManager : MonoBehaviour
{
    public static bool PauseSim; //Pausiert RotateAround Scrips

    public static bool ambienceIsPlaying;

    public static bool firstImageTracked;

    public static bool onPageChanged;

    public static bool infoButtonsOff;
    // Start is called before the first frame update
    void Start()
    {
        onPageChanged = false;
        PauseSim = false;
        ambienceIsPlaying = true;
        firstImageTracked = false;
        infoButtonsOff = false;
    }
    
    //Pausiert die meißten Bewegungen
    public void PauseScene()
    {
        PauseSim = !PauseSim;
    }
}
