using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected CapsuleCollider capsuleCollider;
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCapsuleCollider();
        LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.GetComponentInParent<EnemyCtrl>();
        Debug.LogWarning($"{transform.name}: LoadEnemyCtrl", gameObject);
    }

    protected virtual void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider>();
        this.capsuleCollider.isTrigger = true;
        this.capsuleCollider.radius = 1.2f;
        this.capsuleCollider.height = 6f;
        this.capsuleCollider.center = new Vector3(0f, 1f, 0f);
        Debug.LogWarning($"{transform.name}: LoadCapsuleCollider", gameObject);
    }

    protected override void OnDead()
    {
        this.enemyCtrl.Animator.SetBool("isDead", this.isDead);
    }

    protected override void OnHurt()
    {
        this.enemyCtrl.Animator.SetTrigger("isHurt");
    }
}
