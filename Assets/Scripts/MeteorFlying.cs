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

        //Eine zufälige Startposition innerhalb einer Sphere wird generiert
        startpos = new Vector3(-2,(Random.insideUnitSphere.y*0.1f)-0.3f,(Random.insideUnitSphere.z*0.2f)+0.5f);

        //Der Vektor anhand dessen der Asteorid fliegt wird erstellt. Er wird innerhab einer Range gehalten um die Asteoriden zielgerichtet auf das Schiff zufliegen zu lassen
        fightDirection = new Vector3(Random.Range(0.1f,1f),Random.Range(-0.05f,0.05f),Random.Range(-0.1f,0.1f));

        //Dauer, in der die Asteoriden-GameObjects innerrhalb der Szene existieren
        lifetime = 8;

        //Das Asteoriden-GameObject wird an die Startposition gesetzt 
        gameObject.transform.position = startpos;

        //Skalierung des Objektes auf eine zufällige Größe
        meteorScale = Random.Range(0.005f,0.04f);
        gameObject.transform.localScale = new Vector3(meteorScale,meteorScale,meteorScale);

    }

    
    void Update()
    {
        //Asteoriden-GameObject wird mit den bestimmten Variablen animiert und nach Ablauf der Lifetime zerstört
        gameObject.transform.Rotate(Random.Range(0.01f,0.2f),Random.Range(0.01f,0.2f),Random.Range(0.01f,0.2f),Space.Self);
        gameObject.transform.Translate(fightDirection*Time.deltaTime,Space.World);
        Destroy(gameObject, lifetime);

        //Wenn wenn das eigene Prefab nicht mehr aktiv in der Szene ist, werden die noch in der Szene befindlichen Meteoriten zerstört
        if(!GameObject.Find("P5 MeteorField(Clone)").activeInHierarchy){
            Destroy(gameObject);
        }
    }
}
