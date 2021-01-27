using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instatiateMeteors : MonoBehaviour
{
   
    public  GameObject [] asteroiden;
    
    

    void Start(){
        

        StartCoroutine(startMeteors());
    }
    
    
    IEnumerator startMeteors()
    {
        while (gameObject.active){
            GameObject.Instantiate(asteroiden[(int)(Random.Range(1f,3f))]);
            yield return new WaitForSeconds(Random.Range(0.1f,2f));

        }
    }
}
