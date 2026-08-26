using System;

public class Item
{
	public string ItemName {get; set; }
	public List<ItemEffect> ListOfEffects { get; set; }
	public ItemRarity Rarity { get; set; }

	public Item(string itemName, ItemRarity rarity ,List<ItemEffect> effects)
	{
		ItemName = itemName;
		Rarity = rarity;
		ListOfEffects = effects;
	}

}
