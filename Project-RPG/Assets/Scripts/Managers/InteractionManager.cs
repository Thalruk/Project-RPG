using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance;

    [SerializeField] private List<Interactable> interactables;

    [SerializeField] private GameObject interactablePanel;
    [SerializeField] private TMP_Text interactableText;

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
        RefreshInteractionUI();
    }

    public bool RemoveInteractable(Interactable interactable)
    {
        bool result = interactables.Remove(interactable);
        RefreshInteractionUI();
        return result;
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

    public void RefreshInteractionUI()
    {
        if (interactables.Count > 0)
        {
            interactablePanel.SetActive(true);
            if (interactables[0].GetType() == typeof(Interactable))
            {
                interactableText.text = "Press E to interact";
            }
            else if (interactables[0].GetType() == typeof(Pickable))
            {
                interactableText.text = "Press E to pick up Item";
            }
        }
        else
        {
            interactablePanel.SetActive(false);
        }
    }
}
