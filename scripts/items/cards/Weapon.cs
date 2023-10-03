public class Weapon : Card
{
    public int Damage {get; set;}
    public int Durability {get; set;}

    public Weapon(int cost, string name, Rarity rarity, Unique unique, string description, int damage, int durability) 
    : base(cost, name, rarity, unique, description)
    {
        Damage = damage;
        Durability = durability;
    }
}