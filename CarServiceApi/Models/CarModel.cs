using System.Collections.Generic;

public class CarModel 
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int CarBrandId { get; set; }
    public CarBrand CarBrand { get; set; }

    public List<ModelGeneration> ModelGenerations { get; set; } = new List<ModelGeneration>();

}