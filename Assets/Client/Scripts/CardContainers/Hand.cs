using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///����� �������� �� �������� � ����������� ���� � ����
///<summary>
public class Hand
{
    private List<BasicCard> _hand = new(10);

    private int _maxCards = 10;

    public IEnumerator Cards => _hand.GetEnumerator();

    /// <summary>
    /// ������������ ���-�� ���� � ����
    /// </summary>
    public int MaxCards => _maxCards;

    /// <summary>
    /// ������� ���-�� ���� � ����
    /// </summary>
    public int Count => _hand.Count;

    /// <summary>
    /// �������� ���� �� ���������� ����
    /// </summary>
    /// <returns>���� ���� ����� - true. � ��������� ������ - false</returns>
    public bool IsEmpty => _hand.Count == 0;

    /// <summary>
    /// ��������� �� � ���� ������������ ���-�� ����
    /// </summary>
    public bool IsFull => _hand.Count >= _maxCards;

    /// <summary>
    /// ��������� ����� � ����
    /// </summary>
    /// <returns>���������� true � ������ ������ � false � ������ �������.</returns>
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
