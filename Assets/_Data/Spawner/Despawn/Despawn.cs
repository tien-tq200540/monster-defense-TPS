using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : TienMonoBehaviour
{
    [SerializeField] protected Spawner spawner;

    public virtual void SetSpawner(Spawner spawner)
    {
        this.spawner = spawner;
    }
}
