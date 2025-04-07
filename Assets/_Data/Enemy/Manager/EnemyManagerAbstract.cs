using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyManagerAbstract : TienMonoBehaviour
{
    [SerializeField] protected EnemyManagerCtrl enemyManagerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyManagerCtrl();
    }

    protected virtual void LoadEnemyManagerCtrl()
    {
        if (this.enemyManagerCtrl != null) return;
        this.enemyManagerCtrl = GetComponentInParent<EnemyManagerCtrl>();
        Debug.LogWarning($"{transform.name}: LoadEnemyManagerCtrl", gameObject);
    }
}
