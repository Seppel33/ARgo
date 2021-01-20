using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFlying : MonoBehaviour
{
    Vector3 startpos;
    Vector3 fightDirection;

    int lifetime;
    float meteorScale;


    void Start()
    {
        //Random Startopos innerhalb einer Plane wird zugewiesen
        startpos = new Vector3(-7,Random.insideUnitSphere.y*2,Random.insideUnitSphere.z*2);
        //Random Flugvektor
        fightDirection = new Vector3(Random.Range(0.1f,1f),Random.Range(-0.05f,0.05f),Random.Range(-0.1f,0.1f));

        lifetime = 30;


        gameObject.transform.position = startpos;
        meteorScale = Random.Range(0.01f,0.1f);

        gameObject.transform.localScale = new Vector3(meteorScale,meteorScale,meteorScale);

        



    }

    
    void Update()
    {
        gameObject.transform.Rotate(Random.Range(0.05f,0.4f),Random.Range(0.05f,0.4f),Random.Range(0.05f,0.4f),Space.Self);
        gameObject.transform.Translate(fightDirection*Time.deltaTime,Space.World);
        Destroy(gameObject, lifetime);
    }
}
