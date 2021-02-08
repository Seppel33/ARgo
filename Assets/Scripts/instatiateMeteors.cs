using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instatiateMeteors : MonoBehaviour
{
   
   //Array der verfügbaren Meteror-Prefabs
    public  GameObject [] asteroiden;

    //Liste, in der die Meteor-Instanzen gesammelt werden
    public List <GameObject> instanzen; 
    


    void Start(){
        

        StartCoroutine(startMeteors());
    }
    
    //Eines von 3 Meteor Prefabs wird zufällig ausgewählt, instanziiert und der instanzen-Liste zugewiesen
    IEnumerator startMeteors()
    {
        while (gameObject.active){
            GameObject asteor = GameObject.Instantiate(asteroiden[(int)(Random.Range(1f,3f))]);
            instanzen.Add(asteor);
            yield return new WaitForSeconds(Random.Range(0.1f,1f));
        }
    }

    //Wenn das Prefab beim Umblättern zerstört wird, wird die Liste der Meteor-Instanzen auch zerstört
    void OnDestroy()
    {
        foreach (GameObject go in instanzen)
        {
            Destroy(go);
        }
    }
}

