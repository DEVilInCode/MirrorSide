using SharedLibrary.General;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс отвечающий за объект карты
/// </summary>
public abstract class BasicCard : MonoBehaviour
{
    public string Name { get; }
    public Sprite Sprite { get; }
    public string Description { get; }

    public int Cost { get; }

    public Rarity Rarity { get; }
    public Unique Unique { get; }

    public BasicCard(BasicData cardData)
    {
        Name = cardData.name;
        Sprite = cardData.Sprite;
        Description = cardData.Description;
        Cost = cardData.Cost;
        Rarity = cardData.Rarity;
        Unique = cardData.Unique;
    }
}
