using System;
using System.Runtime.CompilerServices;

public class Enemy
{
	public int MaxHealth { get; set; }
	public int CurrentHealth { get; set; }
	public int AttackStat { get; set; }

	public int DefenseStat { get; set; }
	public string EnemyName { get; set; }

	//Item item { get; set; }



	public Enemy(int maxHealth, int attack, int defense, /*Item itemOnPerson,*/ string enemyName)
	{
		MaxHealth = maxHealth;
		CurrentHealth = maxHealth;
		AttackStat = attack;
		DefenseStat = defense;
		EnemyName = enemyName;
		//item = itemOnPerson;
	}

	public void TakeDamage(int damage)
	{
		CurrentHealth -= damage;
		if (CurrentHealth <= 0)
		{
			Console.WriteLine("Beep boop i have dies");
		}
	}
}
