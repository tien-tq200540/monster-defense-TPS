using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class TowerTargetting : TienMonoBehaviour
{
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected EnemyCtrl nearest;
    public EnemyCtrl Nearest => nearest;
    [SerializeField] protected LayerMask obstacleLayerMask;
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
        this.RemoveDeadEnemy();
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
        if (enemy.DamageReceiver.IsDead()) return;
        this.enemies.Add(enemy);
    }

    protected virtual void RemoveEnemy(Collider collider)
    {
        if (collider.name != Const.TOWER_TARGETABLE) return;
        foreach (EnemyCtrl enemy in this.enemies)
        {
            if (enemy.transform == collider.transform.parent)
            {
                if (enemy == this.nearest) this.nearest = null;
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
            if (!this.CanSeeTarget(enemy)) continue;
            curDistance = Vector3.Distance(enemy.transform.position, transform.position);
            if (curDistance < minDistance)
            {
                minDistance = curDistance;
                this.nearest = enemy;
            }
        }
    }

    protected virtual bool CanSeeTarget(EnemyCtrl target)
    {
        Vector3 directionToTarget = target.transform.position - transform.position;
        float distanceToTarget  = directionToTarget.magnitude;

        if (!Physics.Raycast(transform.position, directionToTarget, out RaycastHit hitInfo, distanceToTarget, obstacleLayerMask))
        {
            Vector3 directionToCollider = hitInfo.point - transform.position;
            float distanceToCollider = directionToCollider.magnitude;
            Debug.DrawRay(transform.position, directionToCollider.normalized * distanceToCollider, UnityEngine.Color.red);
            return false;
        }

        Debug.DrawRay(transform.position, directionToTarget.normalized * distanceToTarget, UnityEngine.Color.green);
        return true;
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

    protected virtual void RemoveDeadEnemy()
    {
        foreach (EnemyCtrl enemyCtrl in this.enemies)
        {
            if (enemyCtrl.DamageReceiver.IsDead())
            {
                this.enemies.Remove(enemyCtrl);
                if (this.nearest == enemyCtrl) this.nearest = null;
                return;
            }
        }
    }
}
