using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ���� ����������� ��� ���� � �����
/// </summary>
public abstract class CardData : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public string Description;

    [Min(0)]
    public int Cost;
    
    public Rarity Rarity;
    public Unique Unique;
}
