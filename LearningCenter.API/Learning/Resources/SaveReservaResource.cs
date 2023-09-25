namespace LearningCenter.API.Learning.Resources;

public class SaveReservaResource
{
    public string Date { get; set; }
    public DateTime StartHour { get; set; }
    public DateTime EndHour { get; set; }
    public int EstadoId { get; set; }
    public int ServiceProviderId { get; set; }
    public int ClientPaymentId { get; set; }
}