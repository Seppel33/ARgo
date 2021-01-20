using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instatiateMeteors : MonoBehaviour
{
    public GameObject meteor;

    void Start(){
        StartCoroutine(startMeteors());
    }
    
    
    IEnumerator startMeteors()
    {
        while (gameObject.active){
            GameObject.Instantiate(meteor);
            yield return new WaitForSeconds(Random.Range(0.1f,2f));

        }
    }
}
