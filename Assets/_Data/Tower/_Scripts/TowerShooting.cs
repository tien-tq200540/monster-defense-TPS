using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected int currentIndex = 0;
    [SerializeField] protected float targetLoadSpeed = 1f;
    [SerializeField] protected float shootSpeed = 1f;
    [SerializeField] protected float rotationSpeed = 2f;
    [SerializeField] protected EnemyCtrl target;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.TargetLoading), targetLoadSpeed);
        Invoke(nameof(this.Shooting), shootSpeed);
    }

    protected virtual void FixedUpdate()
    {
        this.Looking();
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
        Invoke(nameof(this.TargetLoading), targetLoadSpeed);
        this.target = this.towerCtrl.TowerTargetting.Nearest;
    }

    protected virtual void Shooting()
    {
        Invoke(nameof(this.Shooting), shootSpeed);
        if (this.target == null) return;
        //Spawner
        FirePoint firePoint = this.GetFirePoint();
        Bullet newBullet = this.towerCtrl.BulletSpawner.Spawn(this.towerCtrl.Bullet, firePoint.transform.position);
        newBullet.transform.forward = firePoint.transform.forward;
        newBullet.gameObject.SetActive(true);
    }

    protected virtual FirePoint GetFirePoint()
    {
        FirePoint firePoint = this.towerCtrl.FirePoints[currentIndex];
        currentIndex++;

        if (currentIndex >= this.towerCtrl.FirePoints.Count)
        {
            currentIndex = 0;
        }
        return firePoint;
    }
}
