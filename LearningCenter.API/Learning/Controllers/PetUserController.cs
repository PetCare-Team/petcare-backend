using AutoMapper;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.Learning.Controllers;

[ApiController]
[Route("/api/v1/pet/{userId}/pet")]
public class PetUserController : ControllerBase
{
    private readonly IPetService _petService;
    private readonly IMapper _mapper;

    public PetUserController(IPetService petService, IMapper mapper)
    {
        _petService = petService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation( 
        Summary = "Get All Pets for given User",
        Description = "Get existing Pets associated with the specified User",
        OperationId = "GetPetUser",
        Tags = new[] { "Pet"}
    )]

     public async Task<IEnumerable<PetResource>> GetAllByUserIdAsync(int userId)
    {
         var pets = await _petService.ListByClientAsync(userId);

         var resources = _mapper.Map<IEnumerable<Pet>, IEnumerable<PetResource>>(pets);

            return resources;
     }
}