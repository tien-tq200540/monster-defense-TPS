using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : TienMonoBehaviour
{
    [SerializeField] protected Transform model;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.LogWarning($"{transform.name}: LoadModel", gameObject);
    }
}
