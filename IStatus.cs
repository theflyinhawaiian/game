using System;

public interface IStatus
{
    List<StatusPart> GetActiveStatusParts();
    string Name { get; set; }
    int Duration { get; set; }
    
}




