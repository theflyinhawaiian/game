using System;

public class MultiStatus: IStatus
{
	public string Name { get; set; }
	public int Duration { get; set; }
	public List<StatusPart> StatusParts { get; set; }

	public MultiStatus(string name, int duration, List<StatusPart> statusParts)
	{
		Name = name;
		Duration = duration;
		StatusParts = statusParts;
	}
	
	public void ApplyStatus(Unit unit)
	{
		foreach (var statusPart in StatusParts)
		{
            MathHelper.ApplyEffect(statusPart.ModificationNumber, statusPart.OperatorSign, statusPart.StatModified, unit);
        }

    }
}
