using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObj : TienMonoBehaviour
{
    [SerializeField] protected DespawnBase despawn;
    public DespawnBase Despawn => despawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDespawn();
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = GetComponentInChildren<DespawnBase>();
        Debug.LogWarning($"{transform.name}: LoadDespawn", gameObject);
    }
}
