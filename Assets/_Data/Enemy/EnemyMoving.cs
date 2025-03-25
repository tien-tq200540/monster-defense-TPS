using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : TienMonoBehaviour
{
    public GameObject target;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public int indexPath = 0;
    [SerializeField] protected Path enemyPath;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyCtrl();
        LoadTarget();
    }

    protected override void Start()
    {
        this.LoadEnemyPath();
    }

    protected virtual void LoadEnemyPath()
    {
        if (this.enemyPath != null) return;
        this.enemyPath = PathsManager.Instance.GetPath(indexPath);
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }

    protected virtual void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.Find("TargetMoving");
    }

    private void FixedUpdate()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        this.enemyCtrl.Agent.SetDestination(target.transform.position);
    }
}
