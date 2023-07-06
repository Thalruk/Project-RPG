using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pickable))]
public class ItemContainer : MonoBehaviour
{
    public Item item;
    private MeshFilter meshFilter;

    private void Awake()
    {
        meshFilter = GetComponentInChildren<MeshFilter>();
        UpdateMesh();
    }

    public void UpdateMesh()
    {
        if (item != null)
        {
            meshFilter.mesh = item.Mesh;
        }
    }
}
