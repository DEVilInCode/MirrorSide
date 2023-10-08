using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///����� �������� �� �������� � ����������� ���� � ����
///<summary>
public class Hand : MonoBehaviour
{
    private List<Card> _hand = new();

    private int _maxCards = 10;

    public int CardOffset;

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
    public bool TryAddCard(CardData cardData)
    {
        if(cardData == null) return false;

        if (_hand.Count >= _maxCards) return false;

        Card newCard = new(cardData, transform.position + new Vector3(_hand.Count * CardOffset - 4, 0, 0), new Quaternion(), transform);

        _hand.Add(newCard);
        return true;
    }
}
