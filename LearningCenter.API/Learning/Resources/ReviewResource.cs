using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Security.Domain.Models;
using LearningCenter.API.Security.Resources;

namespace LearningCenter.API.Learning.Resources;

public class ReviewResource
{
    public int ReviewId { get; set; }
    public string Description { get; set; }
    public int Stars { get; set; }
    public UserResource User { get; set; }
    public ServiceResource Service{ get; set; }
}