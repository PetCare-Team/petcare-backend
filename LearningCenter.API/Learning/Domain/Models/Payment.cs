using LearningCenter.API.Security.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Models;


public class Payment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    
    public string Number { get; set; }

    public DateTime ExpiratedDay { get; set; }
    public int Cvv { get; set; }
    
    // Relationships
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public IList<Reserva> Reservas { get; set; }= new List<Reserva>();
}