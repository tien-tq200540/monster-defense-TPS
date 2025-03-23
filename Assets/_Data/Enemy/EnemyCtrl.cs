using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : TienMonoBehaviour
{
    [SerializeField] protected NavMeshAgent agent;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNavMeshAgent();
    }

    protected virtual void LoadNavMeshAgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
    }
}
