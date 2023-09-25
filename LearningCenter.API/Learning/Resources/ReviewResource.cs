using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Security.Domain.Models;

namespace LearningCenter.API.Learning.Resources;

public class ReviewResource
{
    public int ReviewId { get; set; }
    public string Description { get; set; }
    public int Stars { get; set; }
    public int UserId { get; set; }
    public int ServiceId{ get; set; }
}