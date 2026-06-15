using System;
using System.Security.Cryptography.X509Certificates;

public class Unit
{
	public string Name { get; set; }
	public Inventory Inventory { get; set; }
	public int Level { get; set; } = 1;
	public int BaseHP { get; set; }
	public int EffectiveMaxHP {  get; set; }
	public int CurrentHP {  get; set; }
	public int BaseMovement {  get; set; }
    public int EffectiveMovement { get; set; }
    public int BaseSpeed { get; set; }
	public int EffectiveSpeed { get; set; }
	public float BaseCritChance { get; set; }
	public float EffectiveCritChance { get; set; }
	public int MaxEnergy { get; set; }
	public int CurrentEnergy { get; set; } = 0;
	public int BaseDamage { get; set; } 
	public int EffectiveDamage {  get; set; }
	public float DamageModifier { get; set; } = 1.0f;
	public float DamageReduction { get; set; } = 1.0f;



	public Unit(string name, int level, int baseHP, int baseMovement, int baseSpeed, float baseCritChance, int maxEnergy, int baseDamage, float damageModifier, float damageReduction)
	{
		Name = name;
		Level = level;
		BaseHP = baseHP;
		EffectiveMaxHP = baseHP;
		CurrentHP = baseHP;
		BaseMovement = baseMovement;
		EffectiveMovement = baseMovement;
		BaseSpeed = baseSpeed;
		EffectiveSpeed = baseSpeed;
		BaseCritChance = baseCritChance;
		EffectiveCritChance = baseCritChance;
		MaxEnergy = maxEnergy;
		BaseDamage = baseDamage;
		EffectiveDamage = baseDamage;
		DamageModifier = damageModifier;
		DamageReduction = damageReduction;
		
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
