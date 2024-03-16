using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    public NavMeshAgent agent;
    Transform player;
    private float tickRate = 1.5f;
    private float lastTick = 0;
    public BossStates currentState;
    public Transform attackObject;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (lastTick >= tickRate)
        {
            
        }
        else
        {
            lastTick += Time.deltaTime;
        }
    }
}

public enum BossStates
{
    Idle,
    Stage01,
    Stage02,
    Stage03,
    Death,
}
