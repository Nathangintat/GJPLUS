using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float triggerDistance = 5f; 
    
    private float distanceToTarget = Mathf.Infinity; 
    NavMeshAgent agent;
    bool isProvoked = false;
    
    PlayerSession playerSession;
    FirstPersonController player;
    
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
        
        if (isProvoked)
        {
            EnemyTrigger();
        }
        else if (distanceToTarget <= triggerDistance)
        {
            isProvoked = true;
            //Todo RAGE MODE
            triggerDistance = 5f;
        }
    }

    private void EnemyTrigger()
    {
        {
            if (distanceToTarget >= agent.stoppingDistance)
            {
                transform.LookAt(player.transform.position);
                agent.SetDestination(player.transform.position);
            }

            else if(distanceToTarget <= agent.stoppingDistance)
            {
                AttackPlayer();
            }
        }
    }

    private void AttackPlayer()
    {
        if (!playerSession.GetIsDead())
        {
            //TODO
            //jumpscare
            //sfx
            playerSession.ProcessPlayerDeath();
            Debug.Log(name + "is attacking" + player.name);
            playerSession.SetIsDead(true);
        }
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerDistance);
    }

}
