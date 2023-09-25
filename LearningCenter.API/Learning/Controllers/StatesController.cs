using System.Net.Mime;
using AutoMapper;
using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.Learning.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete States")]
public class StatesController : ControllerBase
{
    private readonly IStateService _stateService;
    private readonly IMapper _mapper;

    public StatesController(IStateService stateService, IMapper mapper)
    {
        _stateService = stateService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<StateResource>), 200)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Get All States",
        Description = "Get a list of all States",
        OperationId = "GetAllStates",
        Tags = new[] { "States" }
    )]
    public async Task<IEnumerable<StateResource>> GetAllAsync()
    {
        var states = await _stateService.ListAsync();
        var resources = _mapper.Map<IEnumerable<State>, IEnumerable<StateResource>>(states);
        return resources;
    }

    [HttpPost]
    [ProducesResponseType(typeof(StateResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Create a new State",
        Description = "Create a new State with the specified information",
        OperationId = "CreateState",
        Tags = new[] { "States" }
    )]
    public async Task<IActionResult> CreateAsync([FromBody] SaveStateResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var state = _mapper.Map<SaveStateResource, State>(resource);
        var result = await _stateService.SaveAsync(state);

        if (!result.Success)
            return BadRequest(result.Message);

        var stateResource = _mapper.Map<State, StateResource>(result.Resource);
        return Ok(stateResource);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(StateResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Update an existing State",
        Description = "Update an existing State with the specified ID and information",
        OperationId = "UpdateState",
        Tags = new[] { "States" }
    )]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveStateResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var state = _mapper.Map<SaveStateResource, State>(resource);
        var result = await _stateService.UpdateAsync(id, state);

        if (!result.Success)
            return BadRequest(result.Message);

        var stateResource = _mapper.Map<State, StateResource>(result.Resource);
        return Ok(stateResource);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(StateResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Delete an existing State",
        Description = "Delete an existing State with the specified ID",
        OperationId = "DeleteState",
        Tags = new[] { "States" }
    )]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _stateService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var stateResource = _mapper.Map<State, StateResource>(result.Resource);
        return Ok(stateResource);
    }
}
