using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����� ������ � ���� �������� ���� ���� ScriptableObject
/// </summary>
public class Deck : MonoBehaviour
{
    public List<CardData> _deck = new();

    /// <summary>
    /// ���������� ���� � ������
    /// </summary>
    public int Count => _deck.Count;

    /// <summary>
    /// ������������ ������
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
    /// ����� ����� �� ���� ������
    /// </summary>
    /// <param name="cardData"></param>
    public void AddOnTop(CardData cardData)
    {
        _deck.Insert(0, cardData);
    }

    /// <summary>
    /// ��������� ����� � ��������� ����� � ������
    /// </summary>
    /// <param name="cardData"></param>
    public void AddInRandom(CardData cardData)
    {
        _deck.Insert(Random.Range(0, _deck.Count + 1), cardData);
    }

    /// <summary>
    /// ���� ����� �� ������
    /// </summary>
    /// <returns>���� ������ ����� - null. � ��������� ������ - CardData</returns>
    public CardData DrawCard()
    {
        if (_deck.Count <= 0)
            return null;

        CardData cardData = _deck[0];

        _deck.RemoveAt(0);
        return cardData;
    }
}
