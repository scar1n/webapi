using System.Collections.Generic;

public class Place 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Area { get; set; }

    public List<Service> Services { get; set; } = new List<Service>();
}