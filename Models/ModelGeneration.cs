using System.Collections.Generic;

public class ModelGeneration
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ProductionStart { get; set; }
    public string ProductinEnd { get; set; }

    public int CarModelId { get; set; }
    public CarModel CarModel { get; set; }

    public List<ClientCar> ClientCars { get; set; } = new List<ClientCar>();
}