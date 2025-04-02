using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class DamageSender : TienMonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected int damage = 1;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadRigidbody();
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = GetComponent<Rigidbody>();
        this.rb.useGravity = false;
        Debug.LogWarning($"{transform.name}: LoadRigidbody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        DamageReceiver damageReceiver = other.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;
        this.SendDamage(damageReceiver);
    }

    protected virtual void SendDamage(DamageReceiver receiver)
    {
        receiver.Deduct(damage);
    }
}
