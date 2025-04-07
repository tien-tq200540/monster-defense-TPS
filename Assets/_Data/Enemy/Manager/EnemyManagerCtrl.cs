using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerCtrl : TienMonoBehaviour
{
    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner => enemySpawner;
    [SerializeField] protected EnemyPrefabs enemyPrefabs;
    public EnemyPrefabs EnemyPrefabs => enemyPrefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
        this.LoadEnemyPrefabs();
    }

    protected virtual void LoadEnemySpawner()
    {
        if (this.enemySpawner != null) return;
        this.enemySpawner = GetComponentInChildren<EnemySpawner>();
        Debug.LogWarning($"{transform.name}: LoadEnemySpawner", gameObject);
    }

    protected virtual void LoadEnemyPrefabs()
    {
        if (this.enemyPrefabs != null) return;
        this.enemyPrefabs = GetComponentInChildren<EnemyPrefabs>();
        Debug.LogWarning($"{transform.name}: LoadEnemyPrefabs", gameObject);
    }
}
