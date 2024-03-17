using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    Transform player;
    public float tickRate = 1.5f;
    private float lastTick = 0;
    public EnemyStates currentState;
    public Transform attackObject;
    public float attackDelay = 2f;
    public GameObject attackEffect;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
            return;
        agent.SetDestination(player.position);

    }
    private void Update()
    {
        if (player != null)
        {
            if (lastTick >= tickRate)
            {
                if (agent.remainingDistance <= agent.stoppingDistance + .2f)
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
        
    }

    IEnumerator AttackRoutine()
    {
        var o = Instantiate(attackEffect, this.transform);
        o.transform.parent = null;
        o.transform.forward = this.transform.forward;
        Destroy(o, .2f);
        attackObject.gameObject.SetActive(true);
        lastTick = 0;
        yield return new WaitForSeconds(.2f);
        attackObject.gameObject.SetActive(false);
        if(player != null)
            agent.SetDestination(player.position);
        else
            StopCoroutine(AttackRoutine());
        yield return new WaitForSeconds(attackDelay);
        StopCoroutine(AttackRoutine());

    }

}

public enum EnemyStates
{
    Follow,
    Attack
}
