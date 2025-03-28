using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : TienMonoBehaviour
{
    public virtual Bullet Spawn(Bullet bulletPrefab)
    {
        Bullet newObject = Instantiate(bulletPrefab);
        return newObject;
    }

    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObject = Instantiate(prefab);
        return newObject;
    }
}
