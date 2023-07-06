using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().inventory.Add(item);
            InventoryManager.Instance.RefreshInventory();
            Destroy(gameObject);
        }
    }
}
