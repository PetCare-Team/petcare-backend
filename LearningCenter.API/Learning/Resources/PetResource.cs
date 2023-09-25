using LearningCenter.API.Security.Resources;

namespace LearningCenter.API.Learning.Resources;

public class PetResource
{
    public int Id { get; set;}
    public string Name { get; set;}
    public string Description { get; set;}
    public int Castrado { get; set;} 
    public int Edad{ get; set; }
    public int UserId { get; set; }
}