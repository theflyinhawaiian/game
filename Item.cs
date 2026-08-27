using System;

public class Item
{
	public string Name {get; set; }
	public List<ItemEffect> ListOfEffects { get; set; }
	public ItemRarity Rarity { get; set; }

	public Item(string itemName, ItemRarity rarity ,List<ItemEffect> effects)
	{
		Name = itemName;
		Rarity = rarity;
		ListOfEffects = effects;
	}

}
