using System;
using System.Runtime.CompilerServices;

public class Enemy
{
	private int MaxHealth { get; set; }
	private int CurrentHealth { get; set; }
	private int AttackStat { get; set; }
	private string EnemyName { get; set; }

	Item item { get; set; }



	public Enemy(int maxHealth, int attack, Item itemOnPerson, string enemyName)
	{
		MaxHealth = maxHealth;
		CurrentHealth = maxHealth;
		AttackStat = attack;
		EnemyName = enemyName;
		item = itemOnPerson;
	}
}
