using System;
using System.Security.Cryptography.X509Certificates;

public class Unit
{
	public int Level { get; set; } = 1;
	public int MaxHP {  get; set; }
	public int CurrentHP {  get; set; }
	public int Move {  get; set; }
	public int Speed { get; set; }
	public int CritChance { get; set; }
	public int MaxEnergy { get; set; }
	public int CurrentEnergy { get; set; }
	public int DamageModifier {  get; set; }



	public Unit(int level, int maxHP, int move, int speed, int critChance, int maxEnergy, int damageModifier)
	{
		Level = level;
		MaxHP = maxHP;
		CurrentHP = maxHP;
		Move = move;
		Speed = speed;
		CritChance = critChance;
		MaxEnergy = maxEnergy;
		CurrentEnergy = maxEnergy;
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
