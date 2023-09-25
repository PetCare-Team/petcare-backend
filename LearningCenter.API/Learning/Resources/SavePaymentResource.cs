using System.ComponentModel.DataAnnotations;

namespace LearningCenter.API.Learning.Resources;

public class SavePaymentResource
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Number { get; set; }
    [Required]
    public DateTime ExpiratedDay { get; set; }
    [Required]
    public int Cvv { get; set; }
    
    [Required]
    public int UserId { get; set; }
}