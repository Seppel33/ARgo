#if UNITY_EDITOR //Nur im Editor nutzbar
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Zeigt die Interpolierte Line im Editor an (wenn object ausgewähtl welches "PathCreator" angehängt hat
[CustomEditor(typeof(PathCreator))]
public class CustomEditorLines : Editor
{
    PathCreator pathCreator;
    Transform[] waypoints;

    /*
    void OnDrawGizmos()
    {
        Debug.Log("Created");
        if(pathCreators == null)
        {
            pathCreators = new PathCreator[1];
            pathCreators[0] = GameObject.Find("Path").GetComponent<PathCreator>();
        }
        else if(timer == updateTime){
            timer++;
            if(timer > 10)
            {
                timer = 0;
            }

            pathCreators[0].UpdateEditorUI();

            Gizmos.DrawLine(new Vector3(0, 0, 0), new Vector3(1, 1, 1));
        }
    }*/
    private void OnEnable()
    {
        pathCreator = (PathCreator)target;


        waypoints = new Transform[pathCreator.transform.childCount];
        for (int i = 0; i < pathCreator.transform.childCount; i++)
        {
            waypoints[i] = pathCreator.transform.GetChild(i);
        }
    }
    private void OnSceneGUI()
    {
        Draw();
    }
    //Zeichnet die Linien im Editor (ähnlich zu PathCreator, nur alles auf einmal berechnet)
    void Draw()
    {
        List<Vector3> linePoints = new List<Vector3>();
        List<Vector3> rotPoints = new List<Vector3>();

        if (waypoints.Length <= 1)
            return;

        int loopBuffer = 0;
        if (pathCreator.loop)
        {
            loopBuffer = 1;
        }
        linePoints.Add(waypoints[0].position);
        for (int i = 0; i < waypoints.Length+loopBuffer-1; i++)
        {
            Vector3 point;
            //Quaternion rot;

            float accuracy = 0.1f; //interpolation Steps between Points
            int anchorNow = i;
            int anchorNext = anchorNow + 1;
            for (float t = accuracy; t < 1; t = t + accuracy)
            {
                switch ((int)pathCreator.interpolationMode)
                {
                    case (0):
                        if (anchorNext >= waypoints.Length)
                        {
                            anchorNext = 0;
                        }
                        point = PathCreator.Lerp(waypoints[anchorNow].position, waypoints[anchorNext].position, t);
                        Vector3 rotPoint = point;
                        rotPoint.y = rotPoint.y + 0.1f;

                        //rot = Quaternion.Lerp(waypoints[anchorNow].rotation, waypoints[anchorNext].rotation, t);
                        

                        linePoints.Add(point);
                        break;
                    case (1):
                        //Debug.Log("Here");
                        int p1;
                        if (anchorNow == 0)
                        {
                            if (pathCreator.loop)
                            {
                                p1 = waypoints.Length - 1;
                            }
                            else
                            {
                                p1 = 0;
                            }
                        }
                        else
                        {
                            p1 = anchorNow - 1;
                        }
                        int p2 = anchorNow;
                        if (anchorNext >= waypoints.Length)
                        {
                            anchorNext = 0;
                        }
                        int p3 = anchorNext;
                        int p4;
                        if (p3 == waypoints.Length - 1)
                        {
                            if (pathCreator.loop)
                            {
                                p4 = 0;
                            }
                            else
                            {
                                p4 = waypoints.Length - 1;
                            }
                        }
                        else
                        {
                            p4 = anchorNext + 1;
                        }
                        //Debug.Log(p1 + " " + p2 + " " + p3 + " " + p4);
                        point = PathCreator.Catmull(waypoints[p1].position, waypoints[p2].position, waypoints[p3].position, waypoints[p4].position, t);
                        //rot = Quaternion.Lerp(waypoints[p2].rotation, waypoints[p3].rotation, t);
                        //Debug.Log(point);
                        linePoints.Add(point);
                        break;
                    case (2):
                        break;
                }
            }
            //Fügt letzten Anchor als Punkt hinzu
            int lastPoint = i+1;
            if (pathCreator.loop)
            {
                if (lastPoint >= waypoints.Length)
                {
                    lastPoint = 0;
                }
            }
            linePoints.Add(waypoints[lastPoint].position);

            //Zeichnet Linie zwischen allen errechneten Punkten
            for(int x = 0; x<linePoints.Count-1; x++)
            {
                //Handles.PositionHandle(linePoints[x], Quaternion.identity);
                Handles.DrawLine(linePoints[x], linePoints[x + 1]);
            }
        }
    }

    
}
#endif