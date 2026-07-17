using System;

public class Ability
{
	public string AbilityName { get; set; }
    public int Damage { get; set; }
    public int Range { get; set; }
    public int Multihits { get; set; }
    public AbilityType AbilityType { get; set; }
	public List<Status>? Statuses { get; set; }
    public List<AbilityEffect>? Effects {  get; set; }

	

	public Ability(string abilityName, int damage, int range, int multihits, AbilityType abilityType, List<Status>? statuses, List<AbilityEffect>? effects)
	{
		AbilityName = abilityName;
		Damage = damage;
		Range = range;
		Multihits = multihits;
		AbilityType = abilityType;
		Statuses = statuses;
		Effects = effects;
		

	}
}
