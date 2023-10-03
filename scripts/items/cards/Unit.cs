public class Unit : Card
{
    public int Damage {get; set;}
    public int Health {get; set;}
    
    public Unit(int cost, string name, Rarity rarity, Unique unique, string description, int damage, int health) 
    : base(cost, name, rarity, unique, description)
    {
        Damage = damage;
        Health = health;
    }
}