using System;

public class TriggerContext	
{
	public Unit Source;
	public Unit? Target;
	public Ability? AbilityUsed;
	public TriggerType TriggerType;

	public TriggerContext(Unit source, TriggerType triggerType)
    {
        Source = source;
        TriggerType = triggerType;
    }
}
