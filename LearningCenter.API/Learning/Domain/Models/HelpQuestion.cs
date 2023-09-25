using LearningCenter.API.Security.Domain.Models;

namespace LearningCenter.API.Learning.Domain.Models;

public class HelpQuestion
{
    public int HelpQuestionID { get; set; }
    public string Title { get; set; }
    public string Question { get; set; }
    public int UserId{ get; set; }
    public User User{ get; set; }
}