using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Security.Domain.Models;
using LearningCenter.API.Security.Resources;

namespace LearningCenter.API.Learning.Resources;

public class ServiceResource
{
    public int ServiceId { get; set; }

    public int Price { get; set; }

    public string Description { get; set; }

    public string Location { get; set; }

    public int Phone { get; set; }

    public int Dni { get; set; }
    
    public bool Cuidador { get; set; }


    public UserResource User {get;set;}
}