using System;

public class ItemEffect
{
    public float ModificationNumber { get; set; }
    public OperatorHandler OperatorSign { get; set; }
    public Stat StatModified { get; set; }

    public ItemEffect(float modificationNumber, OperatorHandler operatorSign, Stat statModified)
	{
        ModificationNumber = modificationNumber;
        OperatorSign = operatorSign;
        StatModified = statModified;
	}
}
