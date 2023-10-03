using Godot;
using System;

public abstract class Card
{
	private int _health;
	private int _damage;
	public string Name {get; set;}
	public Rarity Rarity;
	public int Damage {get {return _damage;} set{ _damage = value;}}
	
	public int Health 
	{
		get 
		{
			return _health;
		}
		set
		{
			_health = Math.Max(0, _health - value);
		}
	}
}
