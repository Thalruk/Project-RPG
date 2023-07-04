using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Legendary
}

[Serializable]
public class Item : ScriptableObject
{
    [Header("Standard")]
    public string Name;
    [TextArea()]
    public string Description;
    public Sprite Sprite;
    public Rarity Rarity;
}
