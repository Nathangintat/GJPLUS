using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RoamingEnemy : MonoBehaviour
{
    [SerializeField] Waypoint waypoint;
    [SerializeField] [Range(0f, 50f)] float speed = 1f;
    [SerializeField] float distanceThreshold = 2f;
    [SerializeField] private float rotateSpeed = 1f;

    private Quaternion rotationGoal;
    private Vector3 directionToWaypoint;
    private Transform currentWaypoint;

    private Enemy enemy;

    public void Start()
    {
        enemy = GetComponent<Enemy>();
        currentWaypoint = waypoint.GetNextWaypoint(currentWaypoint);
        if (currentWaypoint != null)
        {
            transform.position = currentWaypoint.position;
        }

        currentWaypoint = waypoint.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
        if (currentWaypoint != null)
        {
            transform.LookAt(currentWaypoint);
        }
    }

    private void Update()
    {
        if (enemy.currentState == EnemyState.Patrolling)
        {
            FollowPath();
        }
        else if(enemy.currentState == EnemyState.Returning)
        {
            ReturnToClosestWaypoint();
        }
    }

    void FollowPath()
    {
        if (currentWaypoint == null) {return; }

        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, Time.deltaTime * speed);
        if (Vector3.Distance(currentWaypoint.position, transform.position) < distanceThreshold)
        {
            currentWaypoint = waypoint.GetNextWaypoint(currentWaypoint);
        }
        TowardsWaypoint();
    }

    private void ReturnToClosestWaypoint()
    {
        currentWaypoint = waypoint.GetClosestWaypoint(transform.position);
        enemy.currentState = EnemyState.Patrolling;
    }

    private void TowardsWaypoint()
    {
        directionToWaypoint = (currentWaypoint.position - transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(directionToWaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }
}
