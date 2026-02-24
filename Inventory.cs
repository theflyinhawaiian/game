using System;

public class Inventory
{

	public List<Consumable> Consumables { get; set; }

	public Player Player { get; set; }

	public Inventory(Player player)
	{
		Consumables = new List<Consumable>();
		Player = player;
	}
	
	public void GainHealthPotion()
	{
		Consumables.Add(new Consumable(Player));
	}

	public int HealthPotionAmount()
	{
		var consumableAmount = Consumables.Count;
		return consumableAmount;
	}
}
