using LearningCenter.API.Security.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Models;

public class TypeUser
{
    public int TypeUserID { get; set; }
    public string Type { get; set; }

    // Relationships
    public IList<User> Users { get; set; } = new List<User>();
}