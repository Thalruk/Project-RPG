using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Legendary,
    Magical,
    Angelic,
    Demonic
}

[Serializable]
public class Item : ScriptableObject
{
    [Header("Standard")]
    public string Name;
    [TextArea()]
    public string Description;
    public Sprite Sprite;
    public Mesh Mesh;
    public Material[] Materials;
    public Rarity Rarity;

    public virtual void Use()
    {
        Debug.Log(Name + "have been used");
    }
}