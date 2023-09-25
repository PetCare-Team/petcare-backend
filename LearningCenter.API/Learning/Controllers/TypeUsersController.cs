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
[SwaggerTag("Create, read, update and delete Type User")]
public class TypeUsersController : ControllerBase
{
    private readonly ITypeUserService _typeUserService;
    private readonly IMapper _mapper;

    public TypeUsersController(ITypeUserService typeUserService, IMapper mapper)
    {
        _typeUserService = typeUserService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TypeUserResource>), 200)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Get All Type Users",
        Description = "Get a list of all Type Users",
        OperationId = "GetAllTypeUsers",
        Tags = new[] { "TypeUsers" }
    )]
    public async Task<IEnumerable<TypeUserResource>> GetAllAsync()
    {
        var typeUsers = await _typeUserService.ListAsync();
        var resources = _mapper.Map<IEnumerable<TypeUser>, IEnumerable<TypeUserResource>>(typeUsers);
        return resources;
    }

    [HttpPost]
    [ProducesResponseType(typeof(TypeUserResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Create a new Type User",
        Description = "Create a new Type User with the specified information",
        OperationId = "CreateTypeUser",
        Tags = new[] { "TypeUsers" }
    )]
    public async Task<IActionResult> CreateAsync([FromBody] SaveTypeUserResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var typeUser = _mapper.Map<SaveTypeUserResource, TypeUser>(resource);
        var result = await _typeUserService.SaveAsync(typeUser);

        if (!result.Success)
            return BadRequest(result.Message);

        var typeUserResource = _mapper.Map<TypeUser, TypeUserResource>(result.Resource);
        return Ok(typeUserResource);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(TypeUserResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Update an existing Type User",
        Description = "Update an existing Type User with the specified ID and information",
        OperationId = "UpdateTypeUser",
        Tags = new[] { "TypeUsers" }
    )]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveTypeUserResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var typeUser = _mapper.Map<SaveTypeUserResource, TypeUser>(resource);
        var result = await _typeUserService.UpdateAsync(id, typeUser);

        if (!result.Success)
            return BadRequest(result.Message);

        var typeUserResource = _mapper.Map<TypeUser, TypeUserResource>(result.Resource);
            return Ok(typeUserResource);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(TypeUserResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Delete an existing Type User",
        Description = "Delete an existing Type User with the specified ID",
        OperationId = "DeleteTypeUser",
        Tags = new[] { "TypeUsers" }
    )]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _typeUserService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var typeUserResource = _mapper.Map<TypeUser, TypeUserResource>(result.Resource);
        return Ok(typeUserResource);
    }
}
