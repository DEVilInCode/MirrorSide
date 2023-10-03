public abstract class Card
{
	public int Cost {get; set;}
	public string Name {get; set;}
	public Rarity Rarity;
	public Unique Unique;
	public string Description {get; set;}

	//Add image

	public Card(int cost, string name, Rarity rarity, Unique unique, string description)
	{
		Cost = cost;
		Name = name;
		Rarity = rarity;
		Unique = unique;
		Description = description;
	}
}
