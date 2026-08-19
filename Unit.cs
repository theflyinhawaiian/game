using System;
using System.Buffers.Text;

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
	public float BaseDamageModifier { get; set; } = 1.0f;
	public float EffectiveDamageModifier { get; set; } = 1.0f; 
	public float BaseDamageReduction { get; set; } = 1.0f;
	public float EffectiveDamageReduction { get; set; } = 1.0f;
	public List<Ability> Abilities {  get; set; }
	public List<IStatus> Statuses { get; set; }
	public int TimesDefended { get; set; } = 0;
	public int TimesAttacked { get; set; } = 0;


	public Unit(string name, int baseHP, int baseMovement, int baseSpeed, float baseCritChance, int maxEnergy, List<Ability> abilities, List<IStatus> statuses)
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
		Abilities = abilities;
		Statuses = statuses;
	}


	public void CalculateEffectiveStats(TriggerContext triggerContext)
	{
		var activeItemEffects = Inventory.GetActiveItemEffects(triggerContext);
        var intermediateMovement = BaseMovement;
        var intermediateSpeed = BaseSpeed;
        var intermediateCritChance = BaseCritChance;
		var intermediateDamageReduction = BaseDamageReduction;
		var intermediateDamageModifier = BaseDamageModifier;


		foreach (var effect in activeItemEffects)
		{
            switch (effect.StatModified)
            {
                case Stat.Movement:

                    if (effect.OperatorSign == OperatorHandler.Add)
                    {
                        intermediateMovement = intermediateMovement + Convert.ToInt32(effect.ModificationNumber);
                    }
                    else if (effect.OperatorSign == OperatorHandler.Multiply)
                    {
                        intermediateMovement = intermediateMovement * Convert.ToInt32(effect.ModificationNumber);
                    }
                    break;

                case Stat.DamageReduction:

                    if (effect.OperatorSign == OperatorHandler.Add)
                    {
                        intermediateDamageReduction = intermediateDamageReduction + effect.ModificationNumber;
                    }
                    else if (effect.OperatorSign == OperatorHandler.Multiply)
                    {
                        intermediateDamageReduction = intermediateDamageReduction * effect.ModificationNumber;
                    }
                    break;

                case Stat.DamageModifier:

                    if (effect.OperatorSign == OperatorHandler.Add)
                    {
                        intermediateDamageModifier = intermediateDamageModifier + effect.ModificationNumber;
                    }
                    else if (effect.OperatorSign == OperatorHandler.Multiply)
                    {
                        intermediateDamageModifier = intermediateDamageModifier * effect.ModificationNumber;
                    }
                    break;

                case Stat.Speed:

                    if (effect.OperatorSign == OperatorHandler.Add)
                    {
                        intermediateSpeed = intermediateSpeed + Convert.ToInt32(effect.ModificationNumber);
                    }
                    else if (effect.OperatorSign == OperatorHandler.Multiply)
                    {
                        intermediateSpeed = intermediateSpeed * Convert.ToInt32(effect.ModificationNumber);
                    }
                    break;

                case Stat.CritChance:

                    if (effect.OperatorSign == OperatorHandler.Add)
                    {
                        intermediateCritChance = intermediateCritChance + effect.ModificationNumber;
                    }
                    else if (effect.OperatorSign == OperatorHandler.Multiply)
                    {
                        intermediateCritChance = intermediateCritChance * effect.ModificationNumber;
                    }
                    break;
            }
        }
        EffectiveCritChance = intermediateCritChance;
        EffectiveDamageModifier = intermediateDamageModifier;
        EffectiveDamageReduction = intermediateDamageReduction;
        EffectiveMovement = intermediateMovement;
        EffectiveSpeed = intermediateSpeed;




    }
}
