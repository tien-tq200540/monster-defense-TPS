using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : TienMonoBehaviour where T : PoolObj
{
    [SerializeField] protected List<T> inPoolObjs = new();

    public virtual T Spawn(T prefab)
    {
        T newObject = this.GetObjFromPool(prefab);
        if (newObject == null )
        {
            newObject = Instantiate(prefab);
            this.UpdateName(prefab.transform, newObject.transform);
        }
        
        return newObject;
    }

    public virtual T Spawn(T prefab, Vector3 position)
    {
        T newObject = this.Spawn(prefab);
        newObject.transform.position = position;
        return newObject;
    }

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

    protected virtual void UpdateName(Transform prefab, Transform obj)
    {
        obj.name = prefab.name;
    }

    protected virtual void AddObjToPool(T obj)
    {
        this.inPoolObjs.Add(obj);
    }

    protected virtual void RemoveObjFromPool(T obj)
    {
        this.inPoolObjs.Remove(obj);
    }

    protected virtual T GetObjFromPool(T prefab)
    {
        foreach (T inPoolObj in this.inPoolObjs)
        {
            if (prefab.name == inPoolObj.name)
            {
                this.RemoveObjFromPool(inPoolObj);
                return inPoolObj;
            }
        }
        return null;
    }    
}
