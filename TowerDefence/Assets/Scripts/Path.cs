using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private Transform[] points;

    private void Awake()
    {
        points = GetComponentsInChildren<Transform>();
    }

    public Vector3 this[int index]
    {
        get
        {
            return points[index + 1].position;
        }
    }

    public int GetPointCount()
    {
        return points.Length - 1;
    }
}
