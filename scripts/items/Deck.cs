using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class Deck
{
    private static Random _random;
    private List<Card> _deck;

    public Deck()
    {
        _deck = new List<Card>();
        _random = new Random();
    }

    public void Shuffle()
    {
        int n = _deck.Count;
        while(n > 1)
        {
            int k = _random.Next(n-- + 1);
            (_deck[n], _deck[k]) = (_deck[k], _deck[n]);
        }
    }

    public Card DrawCard()
    {
        if(_deck.Count == 0)
            return null;
            
        Card card = _deck[0];
        _deck.RemoveAt(0);
        return card;
    }
}