using System.Text.Json.Serialization;
using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Security.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mail { get; set; }
    public int Phone { get; set; }
    public int Dni { get; set; }
    public int TypeUserId { get; set; }
    public TypeUser TypeUser { get; set; }

    public Service Service { get; set; }

    public IList<Payment> Payments { get; set; }= new List<Payment>();
    public IList<Pet> Pet { get; set; }= new List<Pet>();
    public IList<HelpQuestion> HelpQuestion { get; set; }= new List<HelpQuestion>();
    public IList<Review> Review { get; set; }= new List<Review>();

    [JsonIgnore]
    public string PasswordHash { get; set; }
}