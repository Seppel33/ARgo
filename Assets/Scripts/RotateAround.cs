using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{

    public GameObject rotTarget;
    public int speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(rotTarget.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
