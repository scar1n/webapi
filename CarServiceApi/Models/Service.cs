using System.Collections.Generic;

public class Service 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ServiceCost { get; set; }

    public int InstrumentId { get; set; }
    public Instrument Instrument { get; set; }

    public int PlaceId { get; set; }
    public Place Place { get; set; }

    public List<CompletedService> CompletedServices { get; set; }
}