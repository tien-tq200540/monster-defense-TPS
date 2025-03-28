using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected float rotationSpeed = 2f;
    [SerializeField] protected EnemyCtrl target;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.TargetLoading), 1f);
    }

    protected virtual void FixedUpdate()
    {
        this.Looking();
        this.Shooting();
    }

    protected virtual void Looking()
    {
        if (this.target == null) return;

        Vector3 directionToTarget = this.target.transform.position - this.towerCtrl.Rotator.transform.position;
        Vector3 newDirection = Vector3.RotateTowards(
            this.towerCtrl.Rotator.forward,
            directionToTarget,
            rotationSpeed * Time.fixedDeltaTime,
            0.0f
        );

        //Apply the new direction to the rotator
        this.towerCtrl.Rotator.rotation = Quaternion.LookRotation(newDirection);
        
        //this.towerCtrl.Rotator.LookAt(target.transform.position);
    }

    protected virtual void TargetLoading()
    {
        Invoke(nameof(this.TargetLoading), 1f);
        this.target = this.towerCtrl.TowerTargetting.Nearest;
    }

    protected virtual void Shooting()
    {
        if (this.target == null) return;
        //Spawner
        this.towerCtrl.BulletSpawner.Spawn(this.towerCtrl.Bullet);
    }
}
