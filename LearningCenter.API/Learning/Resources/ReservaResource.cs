using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Learning.Resources;

public class ReservaResource
{
    public int ReservaId { get; set; }
    public string Date { get; set; }
    public DateTime StartHour { get; set; }
    public DateTime EndHour { get; set; }
    public int EstadoId { get; set; }
    public int ServiceProviderId { get; set; }
    public int ClientPaymentId { get; set; }
}