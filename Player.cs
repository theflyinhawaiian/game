using System;

public class Player
{
	public int MaxHealth { get; set; }
	public int CurrentHealth { get; set; }
	public int AttackStat {  get; set; }
	public int DefenseStat { get; set; }
	public Inventory Inventory { get; set; } 

	public Player(int maxHealth, int attack, int defense) 
	{
		MaxHealth = maxHealth;
		CurrentHealth = maxHealth;
		AttackStat = attack;
		DefenseStat = defense;
		Inventory = new Inventory(this);
	}

	public void TakeDamage(int damage)
	{
		CurrentHealth -= damage;
		if (CurrentHealth <= 0)
		{
			Console.WriteLine("GAME OVER");
		}
	}
	
}
