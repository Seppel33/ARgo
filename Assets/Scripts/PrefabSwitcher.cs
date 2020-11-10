using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation
{
    [RequireComponent(typeof(ARTrackedImageManager))]
    public class PrefabSwitcher : MonoBehaviour
    {
        ARTrackedImageManager m_TrackedImageManager;
        [Tooltip("Reference Image Library")]
        public XRReferenceImageLibrary m_ImageLibrary;
        [SerializeField]
        GameObject[] m_Prefabs = new GameObject[8];
        Dictionary<string, GameObject> m_InstatiatedPrefabs;

        string lastImage = "";

        private void Awake()
        {
            m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
            m_TrackedImageManager.requestedMaxNumberOfMovingImages = 1;
            m_InstatiatedPrefabs = new Dictionary<string, GameObject>();
        }

        void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

        void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

        void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            foreach (var newImage in eventArgs.added)
            {
                // Handle added event

                //resize image
                //var minLocalScalar = Mathf.Min(newImage.size.x, newImage.size.y) / 2;
                //newImage.transform.localScale = new Vector3(minLocalScalar, minLocalScalar, minLocalScalar);

                //add new Prefab
                int i = m_ImageLibrary.indexOf(newImage.referenceImage);
                if( i <= m_Prefabs.Length)
                {
                    GameObject prefab = m_Prefabs[i];
                    m_InstatiatedPrefabs.Add(newImage.referenceImage.name ,Instantiate(prefab, newImage.transform));
                    m_InstatiatedPrefabs[newImage.referenceImage.name].gameObject.transform.Rotate(new Vector3(1, 0, 0), 90f);
                    m_InstatiatedPrefabs[newImage.referenceImage.name].name = newImage.referenceImage.name;
                    ChangePage(newImage);
                }

                //D.LogNR("OnChanged.added " + newImage.referenceImage.name);
            }

            foreach (var updatedImage in eventArgs.updated)
            {
                // Handle updated event

                //if tracking an image (new or current)
                if(updatedImage.trackingState == TrackingState.Tracking)
                {
                    ChangePage(updatedImage);
                }

                //D.LogNR("OnChanged.updated " + updatedImage.referenceImage.name + " " + updatedImage.trackingState);
            }

            foreach (var removedImage in eventArgs.removed)
            {
                // Handle removed event
                // never gets called on ARCore
            }
        }
        void ChangePage(ARTrackedImage newPage)
        {
            
            //if it is a new Page
            if (!newPage.referenceImage.name.Equals(lastImage))
            {
                //deactivte old page prefab
                if(lastImage.Length > 0)
                {
                    m_InstatiatedPrefabs[lastImage].SetActive(false);
                }

                //activete new page prefab
                m_InstatiatedPrefabs[newPage.referenceImage.name].SetActive(true);

                lastImage = newPage.referenceImage.name;
            }
        }
    }
}
