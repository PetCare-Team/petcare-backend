using AutoMapper;
using LearningCenter.API.Security.Domain.Models;
using LearningCenter.API.Security.Domain.Services;
using LearningCenter.API.Security.Domain.Services.Communication;
using LearningCenter.API.Security.Resources;
using LearningCenter.API.Security.Authorization.Attributes;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.Security.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
[SwaggerTag("Create, read, update and delete users")]
public class UsersController: ControllerBase
{   
    private readonly IUserService _userService;
    private readonly IMapper _mapper;


    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    [AllowAnonymous]
    [HttpPost("sign-in")]
    [SwaggerOperation(
        Summary = "Validate a user",
        Description = "Validate if the user exist sending its email and password") 
    ]
    [ProducesResponseType(typeof(AuthenticateResponse), 200)]
    [ProducesResponseType(typeof(List<string>), 404)]
    [ProducesResponseType(500)]
    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
        var response = await _userService.Authenticate(request);
        Console.WriteLine(response);

        return (response);
    }


    
    [AllowAnonymous]
    [HttpPost("sign-up")]
    [SwaggerOperation(
        Summary = "Create a user",
        Description = "Add a new user sending all the information about it") 
    ]
    [ProducesResponseType(typeof(UserResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _userService.RegisterAsync(request);
        return Ok(new { message = "Registration successful" });
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "See users",
        Description = "See all the information of the users") 
    ]
    [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
        return Ok(resources);
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "See a user",
        Description = "See the information of an specified user by its Id") 
    ]
    [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        var resource = _mapper.Map<User, UserResource>(user);
        return Ok(resource);
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update a user",
        Description = "Change the information of a user giving the specified Id") 
    ]
    [ProducesResponseType(typeof(UserResource), 200)]
    [ProducesResponseType(typeof(List<string>), 404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Update(int id, UpdateRequest request)
    {
        await _userService.UpdateAsync(id, request);
        return Ok(new { message = "User updated successfully" });
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a user",
        Description = "Delete a user giving the specified Id") 
    ]
    [ProducesResponseType(typeof(UserResource), 200)]
    [ProducesResponseType(typeof(List<string>), 404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteAsync(id);
        return Ok(new { message = "User deleted successfully" });
    }
    
}