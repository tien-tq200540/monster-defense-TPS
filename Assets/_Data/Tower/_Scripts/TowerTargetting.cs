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
    public EnemyCtrl Nearest => nearest;
    [SerializeField] protected List<EnemyCtrl> enemies = new(); //list of enemy in range attack

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
        this.LoadSphereCollider();
    }

    protected virtual void FixedUpdate()
    {
        this.FindNearest();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        this.AddEnemy(other);
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        this.RemoveEnemy(other);
    }

    protected virtual void AddEnemy(Collider collider)
    {
        if (collider.name != Const.TOWER_TARGETABLE) return;
        EnemyCtrl enemy = collider.transform.parent.GetComponent<EnemyCtrl>();
        this.enemies.Add(enemy);
    }

    protected virtual void RemoveEnemy(Collider collider)
    {
        if (collider.name != Const.TOWER_TARGETABLE) return;
        foreach (EnemyCtrl enemy in this.enemies)
        {
            if (enemy.transform == collider.transform.parent)
            {
                this.enemies.Remove(enemy);
                return;
            }
        }
    }

    protected virtual void FindNearest()
    {
        float minDistance = Mathf.Infinity;
        float curDistance;

        if (this.enemies.Count == 0)
        {
            this.nearest = null;
            return;
        }

        foreach (EnemyCtrl enemy in this.enemies)
        {
            curDistance = Vector3.Distance(enemy.transform.position, transform.position);
            if (curDistance < minDistance)
            {
                minDistance = curDistance;
                this.nearest = enemy;
            }
        }
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
