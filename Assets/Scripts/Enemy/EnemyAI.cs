using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    Transform player;
    private float tickRate = 1.5f;
    private float lastTick = 0;
    public EnemyStates currentState;
    public Transform attackObject;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.SetDestination(player.position);

    }
    private void Update()
    {
        if (lastTick >= tickRate)
        {
            if (agent.remainingDistance <=  agent.stoppingDistance+ .2f)
            {
                currentState = EnemyStates.Attack;
            }
            else
            {
                currentState = EnemyStates.Follow;
            }

            switch (currentState)
            {
                case EnemyStates.Follow:
                    agent.SetDestination(player.position);
                    break;
                case EnemyStates.Attack:
                    StartCoroutine(AttackRoutine());
                    break;
                default:
                    break;
            }
        }
        else
        {
            lastTick += Time.deltaTime;
        }
    }

    IEnumerator AttackRoutine()
    {
        attackObject.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        attackObject.gameObject.SetActive(false);
        agent.SetDestination(player.position);
        StopCoroutine(AttackRoutine());

    }

}

public enum EnemyStates
{
    Follow,
    Attack
}
