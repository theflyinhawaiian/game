using System;

public class StatusEffect
{
	public Stat StatModified { get; set; }

	public StatusEffect(Stat statModified)
	{
		StatModified = statModified;
	}
}
