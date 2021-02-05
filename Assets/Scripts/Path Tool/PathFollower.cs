using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField]
    PathCreator path;
    [SerializeField]
    bool destroyOnEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos;
        if (!path.done)
        {
            pos = path.GetNextPos();
            if (pos != null)
            {
                if (destroyOnEnd && path.done)
                {
                    Destroy(gameObject);
                }
                else
                {
                    transform.position = pos;
                }
            }
            transform.rotation = path.newRotation;
        }
        
    }
}
