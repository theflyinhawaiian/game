using System;

public class Consumable : Item
{
	public Player Player { get; set; }


	public Consumable(Player player)
	{
		Player = player;
	}


	public void UseHealthPotion()
	{
		if(Player.Inventory.HealthPotionAmount() > 0)
		{
            if (Player.CurrentHealth < Player.MaxHealth)
            {
                Player.CurrentHealth = Player.CurrentHealth + 5;
                if (Player.CurrentHealth > Player.MaxHealth)
                {
                    Player.CurrentHealth = Player.MaxHealth;
                }
            }
        }
			
	}

}
