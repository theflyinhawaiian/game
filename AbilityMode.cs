using System;

public class AbilityMode
{
	public string ModeName { get; set; }
	public int Damage {  get; set; }
	public int Range { get; set; }
	public AbilityType AbilityType { get; set; }


	public AbilityMode(string modeName, int damage, int range, AbilityType abilityType)
	{ 
		ModeName = modeName;
		Damage = damage;
		Range = range;
		AbilityType = abilityType;
	}
}
