using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : TienMonoBehaviour
{
    [SerializeField] protected Point nextPoint;

    public virtual void LoadNextPoint()
    {
        int curIndex = transform.GetSiblingIndex();
        if (curIndex + 1 < transform.parent.childCount)
        {
            nextPoint = transform.parent.GetChild(curIndex + 1).GetComponent<Point>();
        }
    }
}
