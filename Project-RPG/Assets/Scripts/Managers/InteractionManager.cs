using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance;

    [SerializeField] private List<Interactable> interactables;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    public void AddInteractable(Interactable interactable)
    {
        interactables.Add(interactable);
    }

    public bool RemoveInteractable(Interactable interactable)
    {
        return interactables.Remove(interactable);
    }

    public void Interact()
    {
        if (interactables.Count > 0)
        {
            interactables.First().Interact();
        }
        else
        {
            Debug.Log("There are no things to interact with");
        }
    }
}
