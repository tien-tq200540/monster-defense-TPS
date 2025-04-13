using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class PoolPrefabs<T> : TienMonoBehaviour where T : TienMonoBehaviour
{
    [SerializeField] protected List<T> prefabs = new();

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
        this.prefabs = GetComponentsInChildren<T>().ToList();
        Debug.LogWarning($"{transform.name}: LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (T prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual T GetRandom()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }

    public virtual T GetByName(string name)
    {
        foreach (T prefab in this.prefabs)
        {
            if (prefab.name != name) continue;
            return prefab;
        }

        return null;
    }
}
