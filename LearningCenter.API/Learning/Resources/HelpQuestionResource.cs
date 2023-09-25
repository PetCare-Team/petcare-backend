using LearningCenter.API.Security.Domain.Models;

namespace LearningCenter.API.Learning.Resources;

public class HelpQuestionResource
{
    public int HelpQuestionID { get; set; }
    public string Title { get; set; }
    public string Question { get; set; }
    public int UserId{ get; set; }
}