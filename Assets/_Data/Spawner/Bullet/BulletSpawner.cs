using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    public virtual Bullet Spawn(Bullet bulletPrefab)
    {
        Bullet newObject = Instantiate(bulletPrefab);
        newObject.Despawn.SetSpawner(this);
        return newObject;
    }

    public virtual Bullet Spawn(Bullet bulletPrefab, Vector3 position)
    {
        Bullet newObject = this.Spawn(bulletPrefab);
        newObject.transform.position = position;
        return newObject;
    }
}
