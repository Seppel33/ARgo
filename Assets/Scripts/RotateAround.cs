﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    bool currentRealMode; //true = real Values

    static bool useRealValues;
    //public GameObject rotTarget;
    public float speed; //angle per hour

    public float selfRotate; //angle per hour

    public float distToSun; //mio km
    public float scaledDistToSun;

    public float planetScale; //mio km
    public float scaledPlanetScale;
    void Start()
    {
        currentRealMode = false;
        currentRealMode = SolarContentManager.ShowRealValue;
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, speed* Time.deltaTime * 500);
        transform.GetChild(0).transform.Rotate(Vector3.up, selfRotate* Time.deltaTime * 500);

        if(currentRealMode != SolarContentManager.ShowRealValue)
        {
            currentRealMode = SolarContentManager.ShowRealValue;
            Setup();
        }
        /*if (rotTarget != null)
        {
            transform.RotateAround(rotTarget.transform.position, Vector3.up, (0.0005f * speed) * Time.deltaTime);
        }*/

    }

    void Setup()
    {
        float position;
        float scale;
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
        if (name.Equals("Earth"))
        {
            transform.GetChild(1).transform.localPosition = new Vector3(position, 0, 0);
        }
        transform.GetChild(0).transform.localScale = new Vector3(scale, scale, scale);

        //set lenght of trail

        /*try
        {
            transform.GetChild(0).transform.GetComponentInChildren<TrailRenderer>().time = 0.209f/(position* Mathf.PI * (Mathf.Abs(speed)/180));
        }
        catch { }*/
        try
        {
            ParticleSystem ps = transform.GetChild(0).transform.GetComponentInChildren<ParticleSystem>();
            ps.Stop(); // Cannot set duration whilst Particle System is playing

            var main = ps.main;
            main.startLifetime = (0.04106f * 5) / Mathf.Abs(speed);

            ps.Play();

            //transform.GetChild(0).transform.GetComponentInChildren<ParticleSystem>().gameObject.transform.localScale = SolarContentManager.PrefabScale;
        }
        catch { }
    }
}
