namespace LearningCenter.API.Security.Domain.Services.Communication;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mail { get; set; }

    public int Phone { get; set; }
    public int Dni { get; set; }
    public int TypeUserId { get; set; }

    public string Token { get; set; }
}