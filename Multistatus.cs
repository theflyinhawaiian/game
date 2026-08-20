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
	
	public List<StatusPart> GetActiveStatusParts()
	{
		return StatusParts;
    }
}
