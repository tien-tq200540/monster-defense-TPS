using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPrefabs : TienMonoBehaviour
{
    [SerializeField] protected List<EnemyCtrl> prefabs = new();

    protected override void Awake()
    {
        base.Awake();
        this.HidePrefabs();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        this.prefabs = GetComponentsInChildren<EnemyCtrl>().ToList<EnemyCtrl>();
        Debug.LogWarning($"{transform.name}: LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (EnemyCtrl enemyCtrl in this.prefabs)
        {
            enemyCtrl.gameObject.SetActive(false);
        }
    }

    public virtual EnemyCtrl GetRandom()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
}
