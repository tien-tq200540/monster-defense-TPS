using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : TienMonoBehaviour
{
    [SerializeField] protected int maxHP = 10;
    [SerializeField] protected int currentHP = 10;
    [SerializeField] protected bool isDead = false;
    [SerializeField] protected bool isImmotal = false;

    public virtual int Deduct(int damage)
    {
        if (!this.isImmotal) this.currentHP -= damage;
        if (this.IsDead()) this.OnDead();
        else OnHurt();

        if (this.currentHP < 0) this.currentHP = 0;
        return this.currentHP;
    }

    protected virtual bool IsDead()
    {
        return this.isDead = this.currentHP <= 0;
    }

    protected abstract void OnDead();
    protected abstract void OnHurt();
}
