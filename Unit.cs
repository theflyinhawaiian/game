using System;
using System.Security.Cryptography.X509Certificates;

public class Unit
{
	public string Name { get; set; }
	public int Level { get; set; } = 1;
	public int MaxHP {  get; set; }
	public int CurrentHP {  get; set; }
	public int Move {  get; set; }
	public int Speed { get; set; }
	public float CritChance { get; set; }
	public int MaxEnergy { get; set; }
	public int CurrentEnergy { get; set; } = 0;
	public int Damage { get; set; } 
	public float DamageModifier { get; set; } = 1.0f;



	public Unit(string name, int level, int maxHP, int move, int speed, float critChance, int maxEnergy, int damage, float damageModifier)
	{
		Name = name;
		Level = level;
		MaxHP = maxHP;
		CurrentHP = maxHP;
		Move = move;
		Speed = speed;
		CritChance = critChance;
		MaxEnergy = maxEnergy;
		Damage = damage;
		DamageModifier = damageModifier;
	}

	public void TakeDamage(int damage)
	{
		CurrentHP -= damage;
		if (CurrentHP <= 0)
		{
			Console.WriteLine("This Unit Should be Dead");
		}
	}

}
