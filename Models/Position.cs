using System.Collections.Generic;

public class Position 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Сompetencies { get; set; }

    public List<Employee> Employees { get; set; } = new List<Employee>();
}