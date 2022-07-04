using System.Collections.Generic;

public class Instrument 

{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Accessibility { get; set; }

    public List<Service> Services { get; set; } = new List<Service>();
}