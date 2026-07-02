using System;

public class Ability
{
	public string AbilityName { get; set; }
	public int Damage {  get; set; }
	public int Range {  get; set; }
	public int Mode { get; set; }
	public AbilityType AbilityType { get; set; }

	public Ability(string abilityName, int damage, int range, int mode, AbilityType abilityType)
	{
		AbilityName = abilityName;
		Damage = damage;
		Range = range;
		Mode = mode;
		AbilityType = abilityType;
	}
}
