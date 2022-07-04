public class ClientCar
{
    public int Id { get; set; }
    public int ModelGenerationId { get; set; }
    public ModelGeneration ModelGeneration { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; }

    public int ProductionYear { get; set; }
    public int Milage { get; set; } //km
}