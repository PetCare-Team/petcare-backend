using System.Runtime.InteropServices.JavaScript;

namespace LearningCenter.API.Learning.Domain.Models;

public class Reserva
{
    public int Id { get; set; }
    public string Date { get; set; }
    public DateTime StartHour { get; set; }
    public DateTime EndHour { get; set; }
    public int EstadoId { get; set; }
    public State Estado { get; set; }
    public int ServiceProviderId { get; set; }
    public Service ServiceProvider { get; set; }
    public int ClientPaymentId { get; set; }
    public Payment ClientPayment { get; set; }
}
