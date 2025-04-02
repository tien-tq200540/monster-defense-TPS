using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    [SerializeField] protected SphereCollider sphereCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSphereCollider();
        LoadBullet();
    }

    protected virtual void LoadBullet()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.LogWarning($"{transform.name}: LoadBullet", gameObject);
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.LogWarning($"{transform.name}: LoadSphereCollider", gameObject);
    }

    protected override void SendDamage(DamageReceiver receiver)
    {
        base.SendDamage(receiver);
        this.bulletCtrl.Bullet.Despawn.DoDespawn();
    }
}
