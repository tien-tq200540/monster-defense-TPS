using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class TowerTargetting : TienMonoBehaviour
{
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected EnemyCtrl nearest;
    [SerializeField] protected List<EnemyCtrl> enemies = new(); //list of enemy in range attack

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
        this.LoadSphereCollider();
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.useGravity = false;
        Debug.LogWarning($"{transform.name}: LoadRigidbody", gameObject);
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 10f;
        Debug.LogWarning($"{transform.name}: LoadSphereCollider", gameObject);
    }
}
