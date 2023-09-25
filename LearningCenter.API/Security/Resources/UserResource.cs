using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Resources;

namespace LearningCenter.API.Security.Resources;

public class UserResource
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public int Phone { get; set; }
    public int Dni { get; set; }
    public TypeUserResource TypeUser { get; set; }

    public string Mail { get; set; } 
}