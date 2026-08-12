using System;

public class ItemEffect
{
    public float ModificationNumber { get; set; }
    public OperatorHandler OperatorSign { get; set; }
    public Stat StatModified { get; set; }
    public TriggerType TriggerType { get; set; }
    public Func<TriggerContext, bool> TriggerCondition { get; set; }

    public ItemEffect(float modificationNumber, OperatorHandler operatorSign, Stat statModified, TriggerType triggerType, Func<TriggerContext, bool> triggerCondition)
	{
        ModificationNumber = modificationNumber;
        OperatorSign = operatorSign;
        StatModified = statModified;
        TriggerType = triggerType;
        TriggerCondition = triggerCondition;
	}
}
