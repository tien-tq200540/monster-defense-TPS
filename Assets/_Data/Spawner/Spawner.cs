using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : TienMonoBehaviour
{
    [SerializeField] protected List<T> inPoolObj = new();

    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObject = Instantiate(prefab);
        return newObject;
    }

    public virtual void Despawn(Transform obj)
    {
        Destroy(obj.gameObject);
    }

    public virtual void Despawn(T obj)
    {
        if (obj is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.gameObject.SetActive(false);
            this.AddObjToPool(obj);
        }
    }

    protected virtual void AddObjToPool(T obj)
    {
        this.inPoolObj.Add(obj);
    }
}
