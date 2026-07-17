using System;

public class Status
{
	public string Name { get; set; }
	public int Duration { get; set; }
	public Stat StatModified { get; set; }
	public OperatorHandler OperatorSign { get; set; }
	public float ModificationNumber { get; set; }
	public List<StatusEffect> Effects { get; set; }

	public Status(string name, int duration, Stat statModified, List<StatusEffect> effects)
	{
		Name = name;
		Duration = duration;
		StatModified = statModified;
		Effects = effects;
	}
}
