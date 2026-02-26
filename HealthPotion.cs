using System;

public class HealthPotion : Item
{
	public Player Player { get; set; }


	public HealthPotion(Player player)
	{
		Player = player;
	}


	public void Use()
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
