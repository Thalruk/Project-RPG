using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    public Item item;
    private Rigidbody rb;
    private MeshFilter meshFilter;
    [SerializeField] private AnimationClip clip;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
