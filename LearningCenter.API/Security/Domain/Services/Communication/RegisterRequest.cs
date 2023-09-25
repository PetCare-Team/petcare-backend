using System.ComponentModel.DataAnnotations;

namespace LearningCenter.API.Security.Domain.Services.Communication;

public class RegisterRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Mail { get; set; }

    [Required]
    public int Phone { get; set; }
    [Required]
    public int Dni { get; set; }
    [Required]
    public int TypeUserId { get; set; }


    [Required]
    public string Password { get; set; }
}