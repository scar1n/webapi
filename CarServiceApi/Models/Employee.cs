using System.Collections.Generic;

public class Employee : Person
{
    public int PositionId { get; set; }
    public Position Position { get; set; }

    public List<CompletedService> CompletedServices { get; set; } = new List<CompletedService>();
}