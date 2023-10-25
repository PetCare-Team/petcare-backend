using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Security.Domain.Models;
using LearningCenter.API.Security.Resources;

namespace LearningCenter.API.Learning.Resources;

public class PaymentResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    
    public string Number { get; set; }

    public DateTime ExpiratedDay { get; set; }
    public int Cvv { get; set; }
    public UserResource User { get; set; }
}