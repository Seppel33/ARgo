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

        static string lastLog;

        private void Awake()
        {
            m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
        }

        void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

        void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

        void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            foreach (var newImage in eventArgs.added)
            {
                // Handle added event

                //resize image
                var minLocalScalar = Mathf.Min(newImage.size.x, newImage.size.y) / 2;
                newImage.transform.localScale = new Vector3(minLocalScalar, minLocalScalar, minLocalScalar);

                //add new Prefab
                int i = m_ImageLibrary.indexOf(newImage.referenceImage);
                if( i <= m_Prefabs.Length)
                {
                    GameObject prefab = m_Prefabs[i];
                    GameObject scenePrefab = Instantiate(prefab, newImage.transform);
                }

                D.LogNR("OnChanged.added " + newImage.referenceImage.name);
            }

            foreach (var updatedImage in eventArgs.updated)
            {
                // Handle updated event



                D.LogNR("OnChanged.updated " + updatedImage.referenceImage.name + "\n" + updatedImage.trackingState);
            }

            foreach (var removedImage in eventArgs.removed)
            {
                // Handle removed event
                // never gets called on ARCore
            }
        }
    }
}
