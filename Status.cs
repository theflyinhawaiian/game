using System;

public class Status
{
	public string Name { get; set; }
	public int Duration { get; set; }
	public List<StatusEffect> Effects { get; set; }

	public Status(string name, int duration, List<StatusEffect> effects)
	{
		Name = name;
		Duration = duration;
		Effects = effects;
	}
}
