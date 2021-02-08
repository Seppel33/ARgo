using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TrackingOptimizer : MonoBehaviour
{
    //[SerializeField] private ARSession session;
    [SerializeField] private TextMeshProUGUI debug;
    //public ARTrackedImageManager imageManager;
    public Camera arcam;

    //[SerializeField] private Vector3 trackedImagePosition;
    [SerializeField] private float threshHold = 0.05f;
    [SerializeField] private float waitforseconds = 2;

    //public Rigidbody checkMovement;

    private Vector3 oldPosition;

    private bool cameraMoving;

    private void Start()
    {
        oldPosition = arcam.transform.position;
    }

    void Update()
    {
        //Stoptracking
        //1. When camera is moving or rotating within a threshhold, then stop tracking
        //Checking every 5 Seconds?
            
        //2. Only Readjust position if ray hits image?
        
        //debug.text = checkMovement.velocity + "";
        //After some time has elapsed? Waitforseconds?
        /*if(oldPosition.x - arcam.transform.position.x < threshHold || oldPosition.y < arcam.transform.position.y || oldPosition.z < arcam.transform.position.z){
            print("Camera is Moving");
        }
        oldPosition = arcam.transform.position;*/
        //CameraMoves();
        
        

        //StartCoroutine(CameraMoves());
        if (cameraMoving)
        {
            debug.text = "Camera is moving " + cameraMoving;
        }
        else
        {
            debug.text = "Camera is NOT moving" + cameraMoving;
        }
        
        Debug.Log(cameraMoving);
        
        Invoke("CameraMoves", 5f);
    }

    /*IEnumerator CameraMoves()
    {
        if (Vector3.Distance(oldPosition, arcam.transform.position) > threshHold)
        {
            cameraMoving = true;
            oldPosition = arcam.transform.position;
            yield return new WaitForSeconds(10);
        }

        if (Vector3.Distance(oldPosition, arcam.transform.position) < threshHold)
        {
            cameraMoving = false;
        }
        
    }*/

    void CameraMoves()
    {
        if (Vector3.Distance(oldPosition, arcam.transform.position) < threshHold)
        {
            cameraMoving = false;
        }
        if (Vector3.Distance(oldPosition, arcam.transform.position) > threshHold)
        {
            cameraMoving = true;
            oldPosition = arcam.transform.position;
        }
    }
    
    
}
