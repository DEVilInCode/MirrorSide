using Godot;
using System;

public class Weapon
{
    private string _name;
    private Rarity _rarity;
    private int _strength;
    private int _cost;

    public Weapon()
    {
        _cost = (int)Rarity.Common * 2;
        
    }
    
    
}