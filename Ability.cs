using System;

public class Ability
{
	public string AbilityName { get; set; }
	public List<AbilityMode> Mode {  get; set; }
	

	public Ability(string abilityName, List<AbilityMode> mode)
	{
		AbilityName = abilityName;
		Mode = mode;
	}
}
