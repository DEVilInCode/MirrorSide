using SharedLibrary.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Хранит поля необходимые для карт в общем
/// </summary>
public abstract class BasicData : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    [TextArea(2,3)]
    public string Description;

    [Min(0)]
    public int Cost;
    
    public Rarity Rarity;
    public Unique Unique;
}
