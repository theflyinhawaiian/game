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
	public float BaseDamageModifier { get; set; } = 1.0f;
	public float EffectiveDamageModifier { get; set; } = 1.0f; 
	public float BaseDamageReduction { get; set; } = 1.0f;
	public float EffectiveDamageReduction { get; set; } = 1.0f;
	public List<Ability> Abilities {  get; set; }
	public List<IStatus> Statuses { get; set; }
	public int TimesDefended { get; set; } = 0;
	public int TimesAttacked { get; set; } = 0;


	public Unit(string name, int baseHP, int baseMovement, int baseSpeed, float baseCritChance, int maxEnergy, int baseDamage, List<Ability> abilities, List<IStatus> statuses)
	{
		Name = name;
		Inventory = new Inventory(this);
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
		Abilities = abilities;
		Statuses = statuses;
	}
}
