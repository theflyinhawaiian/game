using System;

public class ItemEffect
{
    public float ModificationNumber { get; set; }
    public OperatorHandler Operator { get; set; }
    public Stat StatModified { get; set; }

    public ItemEffect(float modificationNumber, OperatorHandler operatorSign, Stat statModified)
	{
        ModificationNumber = modificationNumber;
        Operator = operatorSign;
        StatModified = statModified;
	}
}
