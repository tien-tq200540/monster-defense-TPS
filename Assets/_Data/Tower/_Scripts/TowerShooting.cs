using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected EnemyCtrl target;

    protected virtual void FixedUpdate()
    {
        this.LookAtTarget();
    }

    protected virtual void LookAtTarget()
    {
        if (this.target == null) return;

        this.towerCtrl.Rotator.LookAt(target.transform.position);
    }
}
