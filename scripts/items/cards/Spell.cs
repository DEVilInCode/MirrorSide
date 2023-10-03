using System;

public class Spell : Card
{
    public Spell(int cost, string name, Rarity rarity, Unique unique, string description) 
    : base(cost, name, rarity, unique, description)
    {
        
    }
}