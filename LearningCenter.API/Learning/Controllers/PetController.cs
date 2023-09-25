using AutoMapper;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Resources;
using LearningCenter.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.Learning.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[SwaggerTag("Create, read, update and delete Pets")]
public class PetController : ControllerBase
{

    private readonly IPetService _petService;
    private readonly IMapper _mapper;

    public PetController(IPetService petService, IMapper mapper)
    {

        _petService = petService;
        _mapper = mapper;
    }




    [HttpGet]
    [SwaggerOperation(
        Summary = "See pet",
        Description = "See all the pets") 
    ]
    [ProducesResponseType(typeof(IEnumerable<PetResource>), 200)]

    public async Task<IEnumerable<PetResource>> GetAllAsync()
    {

        var pets = await _petService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Pet>, IEnumerable<PetResource>>(pets);

        return resources;
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "See your pet",
        Description = "See a specified pet by its Id") 
    ]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _petService.FindPetByIdAsync(id);
        var resource = _mapper.Map<Pet, PetResource>(user);
        return Created(nameof(GetById), resource);
    }


    [HttpPost]
    [SwaggerOperation(
        Summary = "Save a pet",
        Description = "Add new pet sending all the information about it") 
    ]
    [ProducesResponseType(typeof(PetResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostAsync([FromBody] SavePetResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var pet = _mapper.Map<SavePetResource, Pet>(resource);

        var result = await _petService.SavePetAsync(pet);

        if (!result.Success)
            return BadRequest(result.Message);

        var petResource = _mapper.Map<Pet, PetResource>(result.Resource);

        // return Created(nameof(PostAsync), petResource);
        return Ok(petResource);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update a pet",
        Description = "Change the information of your pet giving the specified Id") 
    ]
    [ProducesResponseType(typeof(List<string>), 404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePetResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var pet = _mapper.Map<SavePetResource, Pet>(resource);
        var result = await _petService.UpdatePetAsync(id, pet);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var petResource = _mapper.Map<Pet, PetResource>(result.Resource);

        return Ok(petResource);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete  Pet",
        Description = "Delete your pet giving the specified Id") 
    ]
    [ProducesResponseType(typeof(PetResource), 200)]
    [ProducesResponseType(typeof(List<string>), 404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _petService.DeletePetAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var petResource = _mapper.Map<Pet, PetResource>(result.Resource);

        return Ok(petResource);
    }
    
}
