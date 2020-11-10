using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CoverManager : MonoBehaviour
{
    GameObject m_mainCamera;
    ARTrackedImageManager m_aRTrackedImageManager;
    GameObject m_otherSideCamera;
    public GameObject coverPlane;

    // Start is called before the first frame update
    void Start()
    {
        m_mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        m_otherSideCamera = GameObject.Find("CoverCam");
        m_aRTrackedImageManager = GameObject.Find("AR Session Origin").GetComponent<ARTrackedImageManager>();
        //UpdateCoverSize();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateCam();
        //UpdateCoverSize();
    }
    void UpdateCam()
    {
        m_otherSideCamera.transform.position = m_mainCamera.transform.position;
        m_otherSideCamera.transform.rotation = m_mainCamera.transform.rotation;
    }
    void UpdateCoverSize()
    {
        foreach (var trackedImage in m_aRTrackedImageManager.trackables)
        {
            if(trackedImage.trackingState == TrackingState.Tracking)
            {
                float newSizeX = trackedImage.size.x;
                float newSizeY = trackedImage.size.y;

                float sizeY = coverPlane.GetComponent<Renderer>().bounds.size.y;
                float sizeX = coverPlane.GetComponent<Renderer>().bounds.size.x;

                Vector3 rescale = coverPlane.transform.localScale;

                rescale.y = newSizeY * rescale.y / sizeY;
                rescale.x = newSizeX * rescale.x / sizeX;

                coverPlane.transform.localScale = rescale;
            }
        }
        
    }
}
