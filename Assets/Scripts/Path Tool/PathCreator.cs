using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public enum InterpolationMode
{
    Lerp,
    Catmull,
    Bezier
};
public class PathCreator : MonoBehaviour
{
    public Transform[] waypoints;
    public bool loop;

    private bool oldLoop;

    private int currentWaypointToReach = 1;
    private int comingFromWaypoint = 0;
    private float time;
    public Quaternion newRotation;
    public bool done = false;

    private void Awake()
    {
        waypoints = new Transform[transform.childCount];
        for(int i = 0; i< transform.childCount; i++)
        {
            waypoints[i] = transform.GetChild(i);
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if(!oldLoop && loop)
        {
            oldLoop = loop;
            if(currentWaypointToReach >= waypoints.Length)
            {
                currentWaypointToReach = 1;
                comingFromWaypoint = 0;
                time = 0;
                done = false;
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
                        time = 0;
                        v = waypoints[comingFromWaypoint].position;
                        done = true;
                        return v;
                    }
                }
            }

            switch ((int)interpolationMode)
            {
                case (0):
                    v = Lerp(waypoints[comingFromWaypoint].position, waypoints[currentWaypointToReach].position, time);
                    newRotation = Quaternion.Lerp(waypoints[comingFromWaypoint].rotation, waypoints[currentWaypointToReach].rotation, time);
                    break;
                case (1):
                    int p1;
                    if (comingFromWaypoint == 0)
                    {
                        if (loop)
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
                        p1 = comingFromWaypoint-1;
                    }

                    int p2 = comingFromWaypoint;
                    int p3 = currentWaypointToReach;
                    int p4;
                    if(currentWaypointToReach == waypoints.Length - 1)
                    {
                        if (loop)
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
                        p4 = currentWaypointToReach + 1;
                    }
                    v = Catmull(waypoints[p1].position, waypoints[p2].position, waypoints[p3].position, waypoints[p4].position, time);
                    newRotation = Quaternion.Lerp(waypoints[p2].rotation, waypoints[p3].rotation, time);
                    break;
                case (2):
                    break;
            }
            return v;
        }
        else
        {
            v = waypoints[comingFromWaypoint].position;
            done = true;
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
