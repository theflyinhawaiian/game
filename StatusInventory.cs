using System;

public class StatusInventory
{
	public List<SingleStatus> Statuses;
	public Unit Unit;

	public StatusInventory(Unit unit)
	{
		Statuses = new List<SingleStatus>();
		Unit = unit;
	}

    public StatusInventory(List<SingleStatus> statuses, Unit unit)
    {
        Statuses = statuses;
        Unit = unit;
    }





	public void StatusModify() 
	{
		foreach (var status in Statuses)
		{
            MathHelper.ApplyEffect(status.ModificationNumber, status.OperatorSign, status.StatModified, Unit);
        }
	}
}
