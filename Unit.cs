using System;

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
	public List<Ability> Abilities {  get; set; }
	public List<IStatus> Statuses { get; set; }
	public int TimesDefended { get; set; } = 0;
	public int TimesAttacked { get; set; } = 0;


	public Unit(string name, int level, int baseHP, int baseMovement, int baseSpeed, float baseCritChance, int maxEnergy, int baseDamage, float damageModifier, float damageReduction, List<Ability> abilities, List<IStatus> statuses)
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
		Abilities = abilities;
		Statuses = statuses;
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
