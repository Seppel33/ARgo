using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameObject Folgt angefügtem Pfad
public class PathFollower : MonoBehaviour
{
    [SerializeField]
    PathCreator path; //zu folgender Pfad
    [SerializeField]
    bool destroyOnEnd; //ob GameObject am Ende des Pfades zerstört werden soll
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos;
        //Fragt ob Pfad durchlaufen wurde
        if (!path.done)
        {
            //erhält die nächste Position auf dem Pfad
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
            //nimmt neue Rotation
            transform.rotation = path.newRotation;
        }
        
    }
}
