using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instatiateMeteors : MonoBehaviour
{
   
    public  GameObject [] asteroiden;
    public List <GameObject> instanzen; 
    
    

    void Start(){
        

        StartCoroutine(startMeteors());
    }
    
    
    IEnumerator startMeteors()
    {
        while (gameObject.active){
            GameObject asteor = GameObject.Instantiate(asteroiden[(int)(Random.Range(1f,3f))]);
            instanzen.Add(asteor);
            yield return new WaitForSeconds(Random.Range(0.1f,1f));
        }
    }


    void OnDestroy()
    {
        foreach (GameObject go in instanzen)
        {
            Destroy(go);
        }
    }
}

