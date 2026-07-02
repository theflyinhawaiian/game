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
	public float BaseDamageModifier { get; set; }
	public float EffectiveDamageModifier { get; set; } 
	public float BaseDamageReduction { get; set; } = 1.0f;
	public float EffectiveDamageReduction { get; set; }
	public Ability? Ability1 { get; set; }
	public Ability? Ability2 { get; set; }
	public Ability? Ability3 { get; set; }
	public Ability? AbilityUltimate { get; set; }




	public Unit(string name, int level, int baseHP, int baseMovement, int baseSpeed, float baseCritChance, int maxEnergy, int baseDamage, float damageModifier, float damageReduction, Ability? ability1, Ability? ability2, Ability? ability3, Ability? abilityUltimate)
	{
		Name = name;
		Inventory = new Inventory(this);
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
		BaseDamageModifier = damageModifier;
		EffectiveDamageModifier = damageModifier;
		BaseDamageReduction = damageReduction;
		EffectiveDamageReduction = damageReduction;
		Ability1 = ability1;
		Ability2 = ability2;
		Ability3 = ability3;
		AbilityUltimate = abilityUltimate;
		
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
