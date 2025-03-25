using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathsManager : Singleton<PathsManager>
{
    [SerializeField] protected List<Path> paths = new();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPaths();
    }

    protected virtual void LoadPaths()
    {
        if (this.paths.Count > 0) return;
        this.paths = GetComponentsInChildren<Path>().ToList();
        foreach (var path in this.paths)
        {
            path.LoadPoints();
        }
        Debug.LogWarning($"{transform.name}: LoadPaths", gameObject);
    }

    public virtual Path GetPath(int index)
    {
        if (index < 0 || index > paths.Count - 1) return null;
        return this.paths[index];
    }

    public virtual Path GetPath(string name)
    {
        foreach (var path in paths)
        {
            if (path.name == name) return path;
        }
        return null;
    }
}
