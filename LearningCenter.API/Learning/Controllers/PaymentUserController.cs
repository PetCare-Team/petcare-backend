using AutoMapper;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.Learning.Controllers;

[ApiController]
[Route("/api/v1/user/{userId}/payment")]
public class PaymentUserController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly IMapper _mapper;

    public PaymentUserController(IPaymentService paymentService, IMapper mapper)
    {
        _paymentService = paymentService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation( 
        Summary = "Get All the payments by User",
        Description = "Get existing methods of payments associated with the specified User",
        OperationId = "GetPaymentUser",
        Tags = new[] { "Payment"}
    )]
     public async Task<IEnumerable<PaymentResource>> GetAllByUserIdAsync(int userId)
    {
         var payments = await _paymentService.GetByUserIdAsync(userId);

         var resources = _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentResource>>(payments);

            return resources;
     }
}