using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : TienMonoBehaviour
{
    public GameObject target;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public int indexPath = 0;
    [SerializeField] protected Path enemyPath;
    [SerializeField] protected Point currentPoint;
    [SerializeField] protected float pointDistance = Mathf.Infinity;
    [SerializeField] protected float stopDistance = 2f;
    [SerializeField] protected bool canMove = false;
    [SerializeField] protected bool isMoving = false;
    [SerializeField] protected bool isFinish = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyCtrl();
        //LoadTarget();
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
        this.CheckMoving();
    }

    protected virtual void Moving()
    {
        if (!this.canMove)
        {
            this.enemyCtrl.Agent.isStopped = true;
            return;
        }

        this.FindNextPoint();

        if (this.currentPoint == null || this.isFinish == true)
        {
            this.enemyCtrl.Agent.isStopped = true;
            return;
        }

        this.enemyCtrl.Agent.isStopped = false;
        this.enemyCtrl.Agent.SetDestination(this.currentPoint.transform.position);
    }

    protected virtual void FindNextPoint()
    {
        if (this.currentPoint == null) this.currentPoint = this.enemyPath.GetPoint(0);

        this.pointDistance = Vector3.Distance(transform.position, this.currentPoint.transform.position);
        if (this.pointDistance <= this.stopDistance)
        {
            this.currentPoint = this.currentPoint.NextPoint;
            if (this.currentPoint == null) this.isFinish = true;
        }
    }

    protected virtual void CheckMoving()
    {
        if (this.enemyCtrl.Agent.velocity.magnitude >= 1f) this.isMoving = true;
        else this.isMoving = false;
        this.enemyCtrl.Animator.SetBool("isMoving", this.isMoving);
    }
}
