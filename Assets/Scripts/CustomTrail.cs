using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ist ein Ersatz für den Trail-Renderer. Ein Line-Renderer der umfunktioniert wurde.
public class CustomTrail : MonoBehaviour
{
    float trailTime = 0.05f;
    public int lenght = 20;
    public float width = 0.01f;
    LineRenderer lineTrail;
    public GameObject Anchor;

    float lastTime;
    int preDelete = 0;
    // Start is called before the first frame update
    void Start()
    {
        lineTrail = transform.GetComponent<LineRenderer>();
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time-lastTime > trailTime)
        {
            //Entfernt die ersten paar Punkte aus der Line, da diese oft nicht an den korrekten Stellen starten
            if (preDelete < 2)
            {
                //lineTrail.startWidth = width;
                //lineTrail.endWidth = width;
                preDelete++;
                RemoveLastPosition(0);
            }

            lastTime = Time.time;
            SetPosition();
        }
        
    }
    /// <summary>
    ///Setzt neue Punkte in die Line
    /// </summary>
    void SetPosition()
    {
        lineTrail.positionCount = lineTrail.positionCount + 1;
        Vector3 posRel = transform.InverseTransformPoint(Anchor.transform.position);
        lineTrail.SetPosition(lineTrail.positionCount - 1, posRel);
        if(lineTrail.positionCount > lenght)
        {
            RemoveLastPosition(lenght);
        }
    }
    //Löscht die letzte(n) Position(en)
    void RemoveLastPosition(int newLenght)
    {
        Vector3[] tempList = new Vector3[newLenght];
        // Calculate how many extra items will need to be cut out from the original list
        int nExtraItems = lineTrail.positionCount - newLenght;
        // Loop through original list and add newest X items to temp list
        for (int i = 0; i < newLenght; i++)
        {
            // shift index by nExtraItems... e.g., if 2 extras, start at index 2 instead of index 0
            tempList[i] = lineTrail.GetPosition(i + nExtraItems);
        }

        // Set the LineRenderer's position list length to the appropriate amount
        lineTrail.positionCount = newLenght;
        // ...and use our tempList to fill it's positions appropriately
        lineTrail.SetPositions(tempList);
    }
}
