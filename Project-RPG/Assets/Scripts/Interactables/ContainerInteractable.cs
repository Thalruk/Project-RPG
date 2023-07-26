using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ContainerInteractable : Interactable
{
    public List<Item> Items;
    Animator anim;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        message = "Press E to open";
        anim = GetComponent<Animator>();
    }

    public override void Interact()
    {
        anim.SetTrigger("Open");
        foreach (Item item in Items)
        {
            Vector3 random = Random.insideUnitCircle;
            Vector3 point = new Vector3(random.x, 0, random.z) + transform.position + offset;

            ItemContainer itemContainer = Instantiate(WorldSettings.Instance.itemContainer, point, Quaternion.identity).GetComponent<ItemContainer>();
            itemContainer.item = item;
            itemContainer.UpdateMesh();
            Debug.Log("container");

        }

        GetComponent<CapsuleCollider>().enabled = false;
        InteractionManager.Instance.RemoveInteractable(this);

        Items.Clear();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + offset, 1);
    }
}
