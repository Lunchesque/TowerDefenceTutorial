using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Color selectionColor;

    private Color standardColor;
    private GameObject tower;

    private void Awake()
    {
        standardColor = meshRenderer.material.color;
    }

    public bool HasTower
    {
        get
        {
            return tower != null;
        }
    }

    public void AddTower(GameObject tower)
    {
        this.tower = tower;
    }

    public void Select(bool on)
    {
        meshRenderer.material.color = on ? selectionColor : standardColor;
    }
}
