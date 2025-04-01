using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : TienMonoBehaviour
{
    [SerializeField] protected int maxHP = 10;
    [SerializeField] protected int currentHP = 10;
    [SerializeField] protected bool isDead = false;

    public virtual int Deduct(int damage)
    {
        this.currentHP -= damage;
        this.IsDead();

        if (this.currentHP < 0) this.currentHP = 0;
        return this.currentHP;
    }

    protected virtual void IsDead()
    {
        this.isDead = this.currentHP <= 0;
    }
}
