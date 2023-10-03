using System.Collections.Generic;

List<Card> cards = new();

Weapon sword = new(2, "Sword", Rarity.Common, Unique.General, "Just a sword",
 2, 2);

Unit worker = new(1, "Worker", Rarity.Common, Unique.General, "Zavodchanin",
 1, 2);


cards.Add(sword);
cards.Add(worker);