using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : TienMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.rotator = this.model.Find("Rotator");
        Debug.LogWarning($"{transform.name}: LoadModel", gameObject);
    }
}
