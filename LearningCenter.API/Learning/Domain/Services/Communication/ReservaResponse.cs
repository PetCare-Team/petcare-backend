using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Shared.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services.Communication;

public class ReservaResponse : BaseResponse<Reserva>
{
    public ReservaResponse(string message) : base(message)
    {
    }

    public ReservaResponse(Reserva resource) : base(resource)
    {
    }
}