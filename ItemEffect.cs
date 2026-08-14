using System;

public class ItemEffect
{
    public float ModificationNumber { get; set; }
    public OperatorHandler OperatorSign { get; set; }
    public Stat StatModified { get; set; }
    public TriggerType TriggerType { get; set; } = TriggerType.Combat;
    public Func<TriggerContext, bool> TriggerCondition { get; set; } = ctx => true;
    public IStatus? Status { get; set; } = null;

    public ItemEffect(float modificationNumber, OperatorHandler operatorSign, Stat statModified)
	{
        ModificationNumber = modificationNumber;
        OperatorSign = operatorSign;
        StatModified = statModified;

	}
}
