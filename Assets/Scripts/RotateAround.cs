using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Erlaubt das Rotieren um einen Ankerpunkt(dieses GameObject) und um die eigene Achse (erstes child)
public class RotateAround : MonoBehaviour
{
    bool currentRealMode; //true = real Values

    //public GameObject rotTarget;
    public float speed; //angle per hour

    public float selfRotate; //angle per hour

    public float distToSun; //mio km
    public float scaledDistToSun;

    public float planetScale; //mio km
    public float scaledPlanetScale; //Unity Scale

    //private TrailRenderer trail;
    public CustomTrail trail; //Trail des Objektes
    void Start()
    {
        currentRealMode = false;
        currentRealMode = SolarContentManager.ShowRealValue;
        Setup();   
    }
    /*
    private void Awake()
    {
        currentRealMode = false;
        currentRealMode = SolarContentManager.ShowRealValue;
        Setup();
    }*/

    // Update is called once per frame
    void Update()
    {
        
        if (!GlobalDataManager.PauseSim)
        {
            //Führt die Rotationen aus
            transform.Rotate(Vector3.up, speed * Time.deltaTime * 500);
            transform.GetChild(0).transform.Rotate(Vector3.up, selfRotate * Time.deltaTime * 500);
        }

       
        if(currentRealMode != SolarContentManager.ShowRealValue)
        {
            //Ändert den Modus wenn nötig
            currentRealMode = SolarContentManager.ShowRealValue;
            Setup();
        }
        
    }
    private void LateUpdate()
    {
        if (trail != null)
        {
            //CorrectTrailPoints();
        }
    }

    //Setzt alle Daten neu (wird beim Erstellen und Modus-Änderung aufgerufen)
    void Setup()
    {
        float position;
        float scale;
        //Wählt Daten aus
        if (currentRealMode)
        {
            position = distToSun;
            scale = planetScale;
        }
        else
        {
            position = scaledDistToSun;
            scale = scaledPlanetScale;
        }
        transform.GetChild(0).transform.localPosition =new Vector3(position,0,0);

        //Speziell für Erde, da es einen eigenen Mond hat
        if (name.Equals("Earth"))
        {
            transform.GetChild(1).transform.localPosition = new Vector3(position, 0, 0);
        }
        transform.GetChild(0).transform.localScale = new Vector3(scale, scale, scale);

        //set lenght of trail
        if (trail != null)
        {
            trail.lenght = (int)((0.168691f / (position * Mathf.PI * (Mathf.Abs(speed) / 180)))*25.1f);
            //trail.width = 1 / 1000;//SolarContentManager.PrefabScale.x/100;
        }

        
        /*try
        {
            ParticleSystem ps = transform.GetChild(0).transform.GetComponentInChildren<ParticleSystem>();
            ps.Stop(); // Cannot set duration whilst Particle System is playing

            var main = ps.main;
            main.startLifetime = (0.04106f * 5) / Mathf.Abs(speed);

            ps.Play();

            //transform.GetChild(0).transform.GetComponentInChildren<ParticleSystem>().gameObject.transform.localScale = SolarContentManager.PrefabScale;
        }
        catch { }*/
    }
    /*
    private void CorrectTrailPoints()
    {
        if (SolarContentManager.relativeSunMovement.x > 0 || SolarContentManager.relativeSunMovement.y > 0 || SolarContentManager.relativeSunMovement.z > 0)
        {
            for (int i = 0; i < trail.positionCount; i++)
            {
                Debug.Log(trail.GetPosition(i) + "; " + transform.position);
                trail.SetPosition(i, trail.GetPosition(i) + SolarContentManager.relativeSunMovement);
                Debug.Log(trail.GetPosition(i));
            }
        }
    } */
}
