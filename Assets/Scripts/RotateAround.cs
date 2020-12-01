using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{

    public GameObject rotTarget;
    public float speed;

    public float selfRotate;

    public float distToSun;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(rotTarget.transform.position, Vector3.up, (0.0005f*speed) * Time.deltaTime);
    }
}
