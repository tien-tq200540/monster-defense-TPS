using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Path : TienMonoBehaviour
{
    [SerializeField] protected List<Point> points = new();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }

    public virtual void LoadPoints()
    {
        if (this.points.Count > 0) return;
        this.points = GetComponentsInChildren<Point>().ToList();
        foreach (var point in this.points)
        {
            point.LoadNextPoint();
        }
        Debug.LogWarning($"{transform.name}: LoadPoints", gameObject);
    }
}
