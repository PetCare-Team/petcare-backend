namespace LearningCenter.API.Learning.Resources;

public class SaveReviewResource
{
    public string Description { get; set; }
    public int ServiceId{ get; set; }
    public int UserId{ get; set; }
    public int Stars { get; set; }
}