using LearningCenter.API.Security.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Models;


public class Service
{
    public int ServiceId { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public int phone { get; set; }
    public int dni { get; set; }
    public bool Cuidador { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    
    public IList<Review> Review { get; set; }= new List<Review>();
    public IList<Reserva> Reservas { get; set; }= new List<Reserva>();
}