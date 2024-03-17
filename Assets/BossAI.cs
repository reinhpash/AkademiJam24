using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BossAI : MonoBehaviour
{
    public NavMeshAgent agent;
    Transform player;
    private float lastTick = 0;
    public HealthBar healthBar;
    public List<Transform> attackPositions = new List<Transform>();
    public StagePrefabList[] stagePrefabLists = new StagePrefabList[3];

    private readonly float[] tickRates = { 2.5f, 2.0f, 1.5f };
    public float[] projectileForces = { 8f, 10f, 12f };

    private BossStates currentState = BossStates.Stage01;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(player != null)
            transform.LookAt(player);
        if (lastTick >= tickRates[(int)currentState])
        {
            UpdateState();
            PerformStateAction();
            lastTick = 0;
        }
        else
        {
            lastTick += Time.deltaTime;
        }
    }

    private void UpdateState()
    {
        if (healthBar.health > healthBar.maxHealth / 2)
        {
            currentState = BossStates.Stage01;
        }
        else if (healthBar.health > healthBar.maxHealth / 4)
        {
            currentState = BossStates.Stage02;
        }
        else
        {
            currentState = BossStates.Stage03;
        }
    }

    private void PerformStateAction()
    {
        switch (currentState)
        {
            case BossStates.Stage01:
                StageAction(0);
                break;
            case BossStates.Stage02:
                StageAction(1);
                break;
            case BossStates.Stage03:
                StageAction(2);
                break;
            case BossStates.Death:
                Death();
                break;
        }
    }

    private void Idle()
    {
        Debug.Log("Idle");
    }

    private void StageAction(int stageIndex)
    {
        if (player != null)
        {
            var p = attackPositions[UnityEngine.Random.Range(0, attackPositions.Count)];
            var r = stagePrefabLists[stageIndex].stagePrefabs[UnityEngine.Random.Range(0, stagePrefabLists[stageIndex].stagePrefabs.Count)];
            GameObject obj = Instantiate(r, Vector3.zero, Quaternion.identity);

            switch (currentState)
            {
                case BossStates.Stage01:
                    obj.transform.position = p.position;
                    obj.transform.forward = p.forward;
                    obj.transform.LookAt(player);
                    break;
                case BossStates.Stage02:
                    obj.transform.position = player.position + new Vector3(0, 5, 0);
                    obj.transform.LookAt(player);
                    break;
                case BossStates.Stage03:
                    int randomChoice = UnityEngine.Random.Range(0, 2);
                    if (randomChoice == 0)
                    {
                        var p3 = attackPositions[UnityEngine.Random.Range(0, attackPositions.Count)];
                        obj.transform.position = p3.position;
                        obj.transform.forward = p3.forward;
                        obj.transform.LookAt(player);
                    }
                    else
                    {
                        obj.transform.position = player.position + new Vector3(0, 5, 0);
                        obj.transform.LookAt(player);
                    }
                    break;
                default:
                    break;
            }

            obj.GetComponent<Rigidbody>().AddForce(obj.transform.forward * projectileForces[stageIndex], ForceMode.Impulse);
        }
    }

    private void Death()
    {
        Debug.Log("Death");
    }

}

[System.Serializable]
public class StagePrefabList
{
    public List<GameObject> stagePrefabs = new List<GameObject>();
}

public enum BossStates
{
    Stage01 = 0,
    Stage02 = 1,
    Stage03 = 2,
    Death,
}
