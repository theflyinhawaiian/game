using System;

public class Item
{
	public string ItemName {get; set; }
	public List<ItemEffect> ListOfEffects { get; set; }

	public Item(string itemName, List<ItemEffect> effects)
	{
		ItemName = itemName;
		ListOfEffects = effects;
	}

}
