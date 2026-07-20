using System;

public class StatusPart
{
    public Stat StatModified { get; set; }
    public OperatorHandler OperatorSign { get; set; }
    public float ModificationNumber { get; set; }

    public StatusPart(Stat statModified, OperatorHandler operatorSign, float modificationNumber)
	{
		StatModified = statModified;
        OperatorSign = operatorSign;
        ModificationNumber = modificationNumber;
	}
}
