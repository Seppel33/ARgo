using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum InterpolationMode
{
    Lerp,
    Catmull,
    Bezier
};
public class PathCreator : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;
    [SerializeField]
    private bool loop;
    [SerializeField]
    private bool showLine;
    private bool oldLoop;

    private int currentWaypointToReach = 1;
    private int comingFromWaypoint = 0;
    private float time;

    private void Update()
    {
        if(!oldLoop && loop)
        {
            oldLoop = loop;
            if(currentWaypointToReach >= waypoints.Length)
            {
                currentWaypointToReach = 1;
            }
        }
    }
    public InterpolationMode interpolationMode = new InterpolationMode();
    public Vector3 GetNextPos()
    {
        Vector3 v = new Vector3();
        if (waypoints.Length > 1 && currentWaypointToReach < waypoints.Length)
        {
            time += Time.deltaTime;

            switch ((int)interpolationMode)
            {
                case (0):
                    if (time > 1)
                    {
                        time = time - (int)time;
                        comingFromWaypoint = currentWaypointToReach;
                        currentWaypointToReach++;
                        if (currentWaypointToReach >= waypoints.Length)
                        {
                            if (loop)
                            {
                                currentWaypointToReach = 0;
                            }
                            else
                            {
                                v = waypoints[comingFromWaypoint].position;
                                return v;
                            }
                        }
                    }
                    v = Lerp(waypoints[comingFromWaypoint].position, waypoints[currentWaypointToReach].position, time);
                    break;
                case (1):
                    if(time > 1)
                    {
                        if (loop)
                        {
                            time = time - (int)time;
                        }
                        else
                        {
                            comingFromWaypoint = waypoints.Length - 1;
                            time = 1;
                        }
                    }
                    v = Catmull(waypoints[0].position, waypoints[1].position, waypoints[2].position, waypoints[3].position, time);
                    break;
                case (2):
                    break;
            }

            
            return v;
        }
        else
        {
            v = waypoints[comingFromWaypoint].position;
            return v;
        }
    }
    public static Vector3 Lerp(Vector3 p0, Vector3 p1, float t)
    {
        return (1.0f - t) * p0 + t * p1;
    }
    public static Vector3 Catmull(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        return ((p1 * 2.0f)
            + (-p0 + p2) * t
            + ((p0 * 2.0f) - (p1 * 5.0f) + (p2 * 4.0f) - p3) * (t * t)
            + (-1 * p0 + (p1 * 3.0f) - (p2 * 3.0f) + p3) * (t * t * t)) * 0.5f;
    }
    public static Vector3 Bezier(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        return (1.0f - t) * (1.0f - t) * (1.0f - t) * p0
            + 3.0f * (1.0f - t) * (1.0f - t) * t * p1
            + 3.0f * (1.0f - t) * t * t * p2
            + t * t * t * p3;
    }
}
