using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : TienMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;
    [SerializeField] protected TowerTargetting towerTargetting;
    public TowerTargetting TowerTargetting => towerTargetting;
    [SerializeField] protected BulletSpawner bulletSpawner;
    public BulletSpawner BulletSpawner => bulletSpawner;
    [SerializeField] protected Bullet bullet;
    public Bullet Bullet => bullet;
    [SerializeField] protected List<FirePoint> firePoints = new();
    public List<FirePoint > FirePoints => firePoints;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadTowerTargetting();
        LoadBulletSpawner();
        LoadBullet();
        LoadFirePoints();
        this.HidePrefabs();
    }

    protected virtual void LoadFirePoints()
    {
        if (this.firePoints.Count > 0) return;
        this.firePoints = new List<FirePoint>(GetComponentsInChildren<FirePoint>());
        Debug.LogWarning($"{transform.name}: LoadFirePoints", gameObject);
    }

    protected virtual void LoadBullet()
    {
        if (this.bullet != null) return;
        this.bullet = GetComponentInChildren<Bullet>();
        Debug.LogWarning($"{transform.name}: LoadBullet", gameObject);
    }

    protected virtual void LoadBulletSpawner()
    {
        if (this.bulletSpawner != null) return;
        this.bulletSpawner = GameObject.FindObjectOfType<BulletSpawner>();
        Debug.LogWarning($"{transform.name}: LoadBulletSpawner", gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.rotator = this.model.Find("Rotator");
        Debug.LogWarning($"{transform.name}: LoadModel", gameObject);
    }

    protected virtual void LoadTowerTargetting()
    {
        if (this.towerTargetting != null) return;
        this.towerTargetting = transform.Find("TowerTargetting").GetComponent<TowerTargetting>();
        Debug.LogWarning($"{transform.name}: LoadTowerTargetting", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        this.bullet.gameObject.SetActive(false);
    }
}
