using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingOpen : MonoBehaviour
{
    [SerializeField] private GameObject[] settingsToggle;
    
    public void MenuOpenClose(bool tog)
    {
        if (tog)
        {
            foreach (GameObject go in settingsToggle)
            {
                go.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject go in settingsToggle)
            {
                go.SetActive(false);
            }
        }
    }
}
