using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Класс отвечающий за объект карты
/// </summary>
public class Card
{
    protected static readonly GameObject _minionPrefab = (GameObject)Resources.Load("MinionCardPrefab");
    protected static readonly GameObject _spellPrefab;
    protected static readonly GameObject _weaponPrefab;

    protected GameObject _card;

    private GameObject _prefab;
    private Vector3 _position;
    private Quaternion _rotation;
    private Transform _parent;

    /// <summary>
    /// Отвечает за создание карт разного типа
    /// </summary>
    /// <param name="cardData"></param>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    /// <param name="parent"></param>
    /// <exception cref="Exception"></exception>
    public Card(CardData cardData, Vector3 position, Quaternion rotation, Transform parent)
    {
        _position = position;
        _rotation = rotation;
        _parent = parent;

        if (cardData is MinionData minionData)
        {
            InstantiateCard(_minionPrefab);
            MinionDisplay minionDisplay = GetDisplayComponent<MinionDisplay>();
            UpdateView(minionDisplay, minionData);
        }
        else if (cardData is SpellData spellData)
        {
            //InstantiateCard(_spellPrefab);
            //SpellDisplay spellDisplay = GetDisplayComponent<SpellDisplay>();
            //UpdateView(spellDisplay, spellData);
        }
        else if (cardData is WeaponData weaponData)
        {

        }
        else
            throw new Exception("Unexpected value");
    }

    private void InstantiateCard(GameObject prefab)
    {
        _card = GameObject.Instantiate(prefab, _position, _rotation, _parent);
    }

    private T GetDisplayComponent<T>() where T : Component
    {
        if (!_card.TryGetComponent(out T displayComponent))
            throw new MissingComponentException(typeof(T).Name);

        return displayComponent;
    }

    private void UpdateView<T>(T display, CardData cardData) where T : CardDisplay
    {
        display.UpdateView(cardData);
    }
}
