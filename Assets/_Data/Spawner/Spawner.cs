using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : TienMonoBehaviour
{
    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObject = Instantiate(prefab);
        return newObject;
    }
}
