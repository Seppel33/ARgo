using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUnhideTextbox : MonoBehaviour
{
    [SerializeField] private GameObject textBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void HideTextbox(bool tog)
    {
        if (tog)
        {
            textBox.SetActive(false);
        }
        else
        {
            textBox.SetActive(true);
        }
    }
}
