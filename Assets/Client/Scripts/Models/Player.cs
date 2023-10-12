using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public Mana Mana;
    public Deck Deck;
    public Hand Hand;

    public Player(Deck deck)
    {
        Deck = deck;
    }
}
