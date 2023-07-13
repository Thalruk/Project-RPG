using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerInteractable : Interactable
{
    public List<Item> Items;
    Animator anim;

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
            Vector3 random = Random.onUnitSphere;
            Vector3 point = new Vector3(random.x, transform.position.y + 0.2f, random.z) + transform.position;

            ItemContainer itemContainer = Instantiate(WorldSettings.Instance.itemContainer, point, Quaternion.identity).GetComponent<ItemContainer>();
            itemContainer.item = item;
            itemContainer.UpdateMesh();
        }

        Items.Clear();
        Debug.Log("container");
    }
}
