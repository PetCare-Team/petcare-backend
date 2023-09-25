using LearningCenter.API.Security.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Models;

public class Pet
{
    public int Id{ get; set; }
    public string Name{ get; set; }
    public string Description{ get; set; }
    
    public int Castrado{ get; set; }
    public int Edad{ get; set; }

    public int UserId{ get; set; }
    public User User{ get; set; }
}