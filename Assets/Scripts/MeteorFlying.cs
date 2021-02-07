using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFlying : MonoBehaviour
{
    Vector3 startpos;
    Vector3 fightDirection;
    int lifetime;
    float meteorScale;
    private GameObject meteorScene;


    void Start()
    {
        meteorScene = GameObject.Find("P4 MeteorField");

        //Eine zufälige Startposition innerhalb einer Sphere wird generiert
        startpos = new Vector3(-7,Random.insideUnitSphere.y*2,Random.insideUnitSphere.z*2);

        //Der Vektor anhand dessen der Asteorid fliegt wird erstellt. Er wird innerhab einer Range gehalten um die Asteoriden zielgerichtet auf das Schiff zufliegen zu lassen
        fightDirection = new Vector3(Random.Range(0.1f,1f),Random.Range(-0.05f,0.05f),Random.Range(-0.1f,0.1f));

        //Dauer, in der die Asteoriden-GameObjects innerrhalb der Szene existieren
        lifetime = 30;

        //Das Asteoriden-GameObject wird an die Startposition gesetzt 
        gameObject.transform.position = startpos;

        //Skalierung des Objektes auf eine zufällige Größe
        meteorScale = Random.Range(0.01f,0.08f);
        gameObject.transform.localScale = new Vector3(meteorScale,meteorScale,meteorScale);

    }

    
    void Update()
    {
        //Asteoriden-GameObject wird mit den bestimmten Variablen animiert und nach Ablauf der Lifetime zerstört
        gameObject.transform.Rotate(Random.Range(0.01f,0.2f),Random.Range(0.01f,0.2f),Random.Range(0.01f,0.2f),Space.Self);
        gameObject.transform.Translate(fightDirection*Time.deltaTime,Space.World);
        Destroy(gameObject, lifetime);

        if(!GameObject.Find("P4 MeteorField").activeInHierarchy){
            Destroy(gameObject);
        }
    }
}
