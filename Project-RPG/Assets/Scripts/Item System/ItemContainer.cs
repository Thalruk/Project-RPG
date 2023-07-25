using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pickable))]
public class ItemContainer : MonoBehaviour
{
    public Item item;
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material defaultMaterial;

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
            if(item.Materials.Length == 0)
            {
                meshRenderer.material = defaultMaterial;
            }
            else
            {
                meshRenderer.materials = item.Materials;
            }
        }
    }
}
