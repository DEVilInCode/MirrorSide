using System;
using System.Collections.Generic;

public abstract class Player
{
    public int Health;
    public string Name;
    public Deck Deck;
    public List<Card> Hand;
    
    public int Mana = 0;

    Player(int health, string name, Deck deck)
    {
        Health = health;
        Name = name;
        Deck = deck;
    }
}