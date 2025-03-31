using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : TienMonoBehaviour
{
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected Despawn<Bullet> despawn;
    public Despawn<Bullet> Despawn => despawn;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDespawn();
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = GetComponentInChildren<Despawn<Bullet>>();
        Debug.LogWarning($"{transform.name}: LoadDespawn", gameObject);
    }
}
