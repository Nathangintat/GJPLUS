using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [Range(1,3)] [SerializeField] private float waypointSize;
    [SerializeField] private bool isMovingForward = true;
    private void OnDrawGizmos()
    {
        foreach (Transform waypoint in transform)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(waypoint.position, waypointSize);
        }
        
        Gizmos.color = Color.magenta;
        for (int i = 0; i < transform.childCount -1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i+1).position);
        }
    }

    public Transform GetNextWaypoint(Transform currentWaypoint)
    {
        if (currentWaypoint == null)
        {
            return transform.GetChild(0);
        }

        int currentIndex = currentWaypoint.GetSiblingIndex();
        int nextIndex = currentIndex;

        if (isMovingForward)
        {
            nextIndex++;
            
            if (nextIndex == transform.childCount)
            {
                nextIndex--;
                isMovingForward = false;
            }
        }

        else
        {
            nextIndex--;
            
            if (nextIndex < 0)
            {
             nextIndex++;
             isMovingForward = true;
            }
        }
        
        return transform.GetChild(nextIndex);
    }
    
    public Transform GetClosestWaypoint(Vector3 position)
    {
        Transform closestWaypoint = null;
        float maxDistance = Mathf.Infinity;

        foreach(Transform wayPoint in transform)
        {
            float targetDistance = Vector3.Distance(position, wayPoint.position);

            if(targetDistance < maxDistance)
            {
                closestWaypoint = wayPoint;
                maxDistance = targetDistance;
            }
        }
        return closestWaypoint;
    }
}
