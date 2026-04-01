using System;

public class ArmorPotion : Item
{
	public Player Player { get; set; }	


	public ArmorPotion(Player player)
	{
		Player = player;
	}

	public void Use()
	{
		Player.DefenseStat = Player.DefenseStat + 3;
	}


}
