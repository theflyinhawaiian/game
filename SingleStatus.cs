using System;

public class SingleStatus: IStatus
{
	public string Name { get; set; }
	public int Duration { get; set; }
	public Stat StatModified { get; set; }
	public OperatorHandler OperatorSign { get; set; }
	public float ModificationNumber { get; set; }

	public SingleStatus(string name, int duration, Stat statModified, OperatorHandler operatorSign, float modificationNumber)
	{
		Name = name;
		Duration = duration;
		StatModified = statModified;
		OperatorSign = operatorSign;
		ModificationNumber = modificationNumber;
	}

	public void ApplyStatus(Unit unit)
	{
		MathHelper.ApplyEffect(ModificationNumber, OperatorSign, StatModified, unit);
	}



}
