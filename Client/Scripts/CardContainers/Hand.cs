using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Класс отвечает за хранение и отображение карт в руке
///<summary>
public class Hand : MonoBehaviour
{
    private List<Card> _hand = new();

    private int _maxCards = 10;

    public int CardOffset;

    /// <summary>
    /// Максимальное кол-во карт в руке
    /// </summary>
    public int MaxCards => _maxCards;

    /// <summary>
    /// Текущее кол-во карт в руке
    /// </summary>
    public int Count => _hand.Count;

    /// <summary>
    /// Проверка руки на отсутствие карт
    /// </summary>
    /// <returns>Если рука пуста - true. В противном случае - false</returns>
    public bool IsEmpty => _hand.Count == 0;

    /// <summary>
    /// Находится ли в руке максимальное кол-во карт
    /// </summary>
    public bool IsFull => _hand.Count >= _maxCards;

    /// <summary>
    /// Добавляет карту в руку
    /// </summary>
    /// <returns>Возвращает true в случае успеха и false в случае неудачи.</returns>
    public bool TryAddCard(CardData cardData)
    {
        if(cardData == null) return false;

        if (_hand.Count >= _maxCards) return false;

        Card newCard = new(cardData, transform.position + new Vector3(_hand.Count * CardOffset - 4, 0, 0), new Quaternion(), transform);

        _hand.Add(newCard);
        return true;
    }
}
