namespace LearningCenter.API.Learning.Domain.Models;

public class State
{
    public int StateID { get; set; }
    public string Description { get; set; }
    public IList<Reserva> Reservas { get; set; }= new List<Reserva>();
}