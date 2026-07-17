using System;

public class StatusInventory
{
	public List<Status> Statuses;
	public Unit Unit;

	public StatusInventory(Unit unit)
	{
		Statuses = new List<Status>();
		Unit = unit;
	}

    public StatusInventory(List<Status> statuses, Unit unit)
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
