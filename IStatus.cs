using System;

public interface IStatus
{
    void ApplyStatus(Unit unit);
    string Name { get; set; }
    int Duration { get; set; }
    
}


