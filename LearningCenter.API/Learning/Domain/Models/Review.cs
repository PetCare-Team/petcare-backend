using LearningCenter.API.Security.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Models;

public class Review
{
    public int ReviewId{ get; set; }
    public int ServiceId { get; set; }
    public int Stars { get; set; }
    public Service Service{ get; set; }
    public int UserId{ get; set; }
    public User User{ get; set; }
    public string Description{ get; set; }
}