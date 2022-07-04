using System.Collections.Generic;

public class Spare
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Cost { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }

    public List<CompletedService> CompletedServices = new List<CompletedService>();

}