using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс хранит в себе описание карт типа ScriptableObject
/// </summary>
public class Deck : MonoBehaviour
{
    public List<CardData> _deck = new();

    /// <summary>
    /// Количество карт в колоде
    /// </summary>
    public int Count => _deck.Count;

    /// <summary>
    /// Перемешивает колоду
    /// </summary>
    public void Shuffle()
    { 
        for(int i = 0; i < _deck.Count; i++)
        {
            int k = Random.Range(0, _deck.Count);   
            (_deck[i], _deck[k]) = (_deck[k], _deck[i]);
        }
    }

    /// <summary>
    /// Кладёт карту на верх колоды
    /// </summary>
    /// <param name="cardData"></param>
    public void AddOnTop(CardData cardData)
    {
        _deck.Insert(0, cardData);
    }

    /// <summary>
    /// Добавляет карту в случайное место в колоде
    /// </summary>
    /// <param name="cardData"></param>
    public void AddInRandom(CardData cardData)
    {
        _deck.Insert(Random.Range(0, _deck.Count + 1), cardData);
    }

    /// <summary>
    /// Берёт карту из колоды
    /// </summary>
    /// <returns>Если колода пуста - null. В противном случае - CardData</returns>
    public CardData DrawCard()
    {
        if (_deck.Count <= 0)
            return null;

        CardData cardData = _deck[0];

        _deck.RemoveAt(0);
        return cardData;
    }
}
