using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> waypoints;

    void OnDrawGizmos()
    {
        if (waypoints != null && waypoints.Count > 0)
        {
            for (int i = 0; i < waypoints.Count; i++)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(waypoints[i % waypoints.Count].position, waypoints[(i + 1) % waypoints.Count].position);
            }
        }
    }
	
}
