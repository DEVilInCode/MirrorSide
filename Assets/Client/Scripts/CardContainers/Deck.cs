using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����� ������ � ���� �������� ���� ���� ScriptableObject
/// </summary>
public class Deck
{
    private List<BasicCard> _deck = new(30);

    /// <summary>
    /// ���������� ���� � ������
    /// </summary>
    public int Count => _deck.Count;

    /// <summary>
    /// ������������ ������
    /// </summary>
    public void Shuffle()
    {
        if (_deck.Count < 2) return;

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
    public void AddOnTop(BasicCard cardData)
    {
        _deck.Insert(0, cardData);
    }

    /// <summary>
    /// ��������� ����� � ��������� ����� � ������
    /// </summary>
    /// <param name="cardData"></param>
    public void AddInRandom(BasicCard cardData)
    {
        _deck.Insert(Random.Range(0, _deck.Count + 1), cardData);
    }

    /// <summary>
    /// ���� ����� �� ������
    /// </summary>
    /// <returns>���� ������ ����� - null. � ��������� ������ - CardData</returns>
    public BasicCard DrawCard()
    {
        if (_deck.Count <= 0)
            return null;

        BasicCard cardData = _deck[0];

        _deck.RemoveAt(0);
        return cardData;
    }
}
