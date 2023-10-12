using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Класс отвечает за хранение и отображение карт в руке
///<summary>
public class Hand
{
    private List<BasicCard> _hand = new(10);

    private int _maxCards = 10;

    public IEnumerator Cards => _hand.GetEnumerator();

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
    public bool TryAddCard(BasicCard card)
    {
        if(card == null) return false;

        if (_hand.Count >= _maxCards) return false;

        _hand.Add(card);

        OnCardAdded();

        return true;
    }

    public event Action CardAdded;

    protected virtual void OnCardAdded()
    {
        CardAdded?.Invoke();
    }
}
