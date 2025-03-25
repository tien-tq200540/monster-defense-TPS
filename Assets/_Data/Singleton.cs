using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : TienMonoBehaviour where T : TienMonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get 
        {
            if ( _instance == null ) Debug.LogError("Singleton doesn't have any instance");
            return _instance;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        this.LoadInstance();
    }

    protected virtual void LoadInstance()
    {
        if (_instance != null)
        {
            Debug.LogError("Only 1 instance of Singleton allows to exists");
        } else
        {
            _instance = this as T;
        }
    }
}
