using System;
using System.Security.Cryptography.X509Certificates;

public class AbilityEffect
{
	public string EffectName { get; set; }
	public int Damage { get; set; }
	public int Range { get; set; }
	public SingleStatus Status { get; set; }

	public AbilityEffect(string effectName, int damage, int range, SingleStatus status)
	{ 
		EffectName = effectName;
		Damage = damage;
		Range = range;
		Status = status;
		
	}
}
