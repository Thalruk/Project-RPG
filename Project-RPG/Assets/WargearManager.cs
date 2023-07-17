using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WargearManager : MonoBehaviour
{
    public static WargearManager Instance;

    [Space(10)]
    [Header("Wargear")]
    public Wargear wargear;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }

    public void Equip(Item item)
    {
        wargear.Equip(item);
    }
}
