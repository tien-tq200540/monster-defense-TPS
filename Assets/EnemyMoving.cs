using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent agent;

    private void Start()
    {
        agent.SetDestination(target.transform.position);
    }
}
