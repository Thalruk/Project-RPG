using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pickable))]
public class ItemContainer : MonoBehaviour
{
    public Item item;
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private MeshRenderer meshRenderer;

    private void Awake()
    {
        UpdateMesh();
    }

    private void OnValidate()
    {
        if(item!= null)
        {
            meshFilter.mesh = item.Mesh;
        }
    }

    public void UpdateMesh()
    {
        if (item != null)
        {
            meshFilter.mesh = item.Mesh;
            meshRenderer.materials = item.Materials;
        }
    }
}
