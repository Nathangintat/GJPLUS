using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float triggerDistance = 5f; 
    [SerializeField] private float returnDistance = 10f;
    [SerializeField] GameObject DeadImage;
    
    private float distanceToTarget = Mathf.Infinity; 
    
    NavMeshAgent agent;
    PlayerSession playerSession;
    FirstPersonController player;
    
    public EnemyState currentState = EnemyState.Patrolling;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
        playerSession = FindFirstObjectByType<PlayerSession>();

        if (distanceToTarget <= triggerDistance)
        {
            triggerDistance += 5f;
        }
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(player.transform.position, transform.position);
        
        switch (currentState)
        {
            case EnemyState.Patrolling:
                Patrolling();
                if (distanceToTarget <= triggerDistance)
                {
                    currentState = EnemyState.Chasing;
                }
                break;

            case EnemyState.Chasing:
                EnemyTrigger();
                if (distanceToTarget > returnDistance)
                {
                    currentState = EnemyState.Returning;
                }
                break;

            case EnemyState.Returning:
                returnToPatrolling();
                if (distanceToTarget <= triggerDistance)
                {
                    currentState = EnemyState.Chasing;
                }
                break;
        }
    }
    
    private void Patrolling()
    {
        agent.ResetPath();
        GetComponentInChildren<Animator>().SetBool("Patrolling", true);
    }

    private void EnemyTrigger()
    {
        {
            if (distanceToTarget >= agent.stoppingDistance)
            {
                GetComponentInChildren<Animator>().SetBool("Patrolling", false);
                GetComponentInChildren<Animator>().SetBool("Rage", true);
                transform.LookAt(player.transform.position);
                agent.SetDestination(player.transform.position);
            }

            else if(distanceToTarget <= agent.stoppingDistance)
            {
                AttackPlayer();
                DeadImage.SetActive(true);
            }
        }
    }

    private void returnToPatrolling()
    {
        GetComponentInChildren<Animator>().SetBool("Rage", false);
        GetComponentInChildren<Animator>().SetBool("Patrolling", true);
        agent.ResetPath();
        currentState = EnemyState.Patrolling;
    }

    private void AttackPlayer()
    {
        if (!playerSession.GetIsDead())
        {
            //TODO
            //jumpscare
            GetComponentInChildren<Animator>().SetTrigger("Attacking");
            playerSession.ProcessPlayerDeath();
            playerSession.SetIsDead(true);
        }
    }

    public bool IsChasing()
    {
        return currentState == EnemyState.Chasing;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerDistance);
    }

}
