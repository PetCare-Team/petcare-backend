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
[SwaggerTag("Create, read, update, and delete Services")]
public class ServicesController : ControllerBase
{
    private readonly IServiceService _serviceService;
    private readonly IMapper _mapper;

    public ServicesController(IServiceService serviceService, IMapper mapper)
    {
        _serviceService = serviceService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ServiceResource>), 200)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Get All Services",
        Description = "Get a list of all Services",
        OperationId = "GetAllServices",
        Tags = new[] { "Services" }
    )]
    public async Task<IEnumerable<ServiceResource>> GetAllAsync()
    {
        var services = await _serviceService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceResource>>(services);
        return resources;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ServiceResource), 200)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Get Service by Id",
        Description = "Get a Service by its Id",
        OperationId = "GetServiceById",
        Tags = new[] { "Services" }
    )]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _serviceService.FindByIdAsync(id);

        if (!result.Success)
            return NotFound(result.Message);

        var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);
        return Ok(serviceResource);
    }

    [HttpGet("user/{userId}")]
    [ProducesResponseType(typeof(IEnumerable<ServiceResource>), 200)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Get All Services by User Id",
        Description = "Get a list of Services by their User's Id",
        OperationId = "GetServicesByUserId",
        Tags = new[] { "Services" }
    )]
    public async Task<IEnumerable<ServiceResource>> GetByUserIdAsync(int userId)
    {
        var services = await _serviceService.FindByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceResource>>(services);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ServiceResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Create a new Service",
        Description = "Create a new Service with the specified information",
        OperationId = "CreateService",
        Tags = new[] { "Services" }
    )]
    public async Task<IActionResult> CreateAsync([FromBody] SaveServiceResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var service = _mapper.Map<SaveServiceResource, Service>(resource);
        var result = await _serviceService.SaveAsync(service);

        if (!result.Success)
            return BadRequest(result.Message);

        var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);
        return Ok(serviceResource);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ServiceResource), 200)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Update an existing Service",
        Description = "Update an existing Service with the specified ID and information",
        OperationId = "UpdateService",
        Tags = new[] { "Services" }
    )]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveServiceResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var service = _mapper.Map<SaveServiceResource, Service>(resource);
        var result = await _serviceService.UpdateAsync(id, service);

        if (!result.Success)
            return BadRequest(result.Message);

        var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);
        return Ok(serviceResource);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ServiceResource), 200)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Delete an existing Service",
        Description = "Delete an existing Service with the specified ID",
        OperationId = "DeleteService",
        Tags = new[] { "Services" }
    )]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _serviceService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);
        return Ok(serviceResource);
    }
}