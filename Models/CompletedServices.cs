public class CompletedService
{
    public int Id { get; set; }
    public int FinalCost { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public int ServiceId { get; set; }
    public Service Service { get; set; }

    public int SpareId { get; set; }
    public Spare Spare { get; set; }

    public int CarQueueId { get; set; }
    public CarQueue CarQueue { get; set; }
}