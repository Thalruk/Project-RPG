using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{ 
    public string Name;
    [TextArea()]
    public string Description;
    public Sprite Sprite;
}
