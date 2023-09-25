using System.Net.Mime;
using AutoMapper;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using LearningCenter.API.Learning.Domain.Models;

namespace LearningCenter.API.Learning.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update, and delete Reservas")]
public class ReservaController : ControllerBase
{
    private readonly IReservaService _reservaService;
    private readonly IMapper _mapper;

    public ReservaController(IReservaService reservaService, IMapper mapper)
    {
        _reservaService = reservaService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ReservaResource>), 200)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Get All Reservas",
        Description = "Get a list of all Reservas",
        OperationId = "GetAllReservas",
        Tags = new[] { "Reservas" }
    )]
    public async Task<IEnumerable<ReservaResource>> GetAllAsync()
    {
        var reservas = await _reservaService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Reserva>, IEnumerable<ReservaResource>>(reservas);
        return resources;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ReservaResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Create a new Reserva",
        Description = "Create a new Reserva with the specified information",
        OperationId = "CreateReserva",
        Tags = new[] { "Reservas" }
    )]
    public async Task<IActionResult> CreateAsync([FromBody] SaveReservaResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var reserva = _mapper.Map<SaveReservaResource, Reserva>(resource);
        var result = await _reservaService.SaveAsync(reserva);

        if (!result.Success)
            return BadRequest(result.Message);

        var reservaResource = _mapper.Map<Reserva, ReservaResource>(result.Resource);
        return Ok(reservaResource);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ReservaResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Update an existing Reserva",
        Description = "Update an existing Reserva with the specified ID and information",
        OperationId = "UpdateReserva",
        Tags = new[] { "Reservas" }
    )]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveReservaResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var reserva = _mapper.Map<SaveReservaResource, Reserva>(resource);
        var result = await _reservaService.UpdateAsync(id, reserva);

        if (!result.Success)
            return BadRequest(result.Message);

        var reservaResource = _mapper.Map<Reserva, ReservaResource>(result.Resource);
        return Ok(reservaResource);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ReservaResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Delete an existing Reserva",
        Description = "Delete an existing Reserva with the specified ID",
        OperationId = "DeleteReserva",
        Tags = new[] { "Reservas" }
    )]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _reservaService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var reservaResource = _mapper.Map<Reserva, ReservaResource>(result.Resource);
        return Ok(reservaResource);
    }

    [HttpGet("byPayment/{paymentId}")]
    [ProducesResponseType(typeof(IEnumerable<ReservaResource>), 200)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Get All Reservas by Payment ID",
        Description = "Get a list of all Reservas based on a specific Payment ID",
        OperationId = "GetReservasByPaymentId",
        Tags = new[] { "Reservas" }
    )]
    public async Task<IEnumerable<ReservaResource>> FindByPaymentIdAsync(int paymentId)
    {
        var reservas = await _reservaService.FindByPaymentIdAsync(paymentId);
        var resources = _mapper.Map<IEnumerable<Reserva>, IEnumerable<ReservaResource>>(reservas);
        return resources;
    }

    [HttpGet("byService/{serviceId}")]
    [ProducesResponseType(typeof(IEnumerable<ReservaResource>), 200)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Get All Reservas by Service ID",
        Description = "Get a list of all Reservas based on a specific Service ID",
        OperationId = "GetReservasByServiceId",
        Tags = new[] { "Reservas" }
    )]
    public async Task<IEnumerable<ReservaResource>> FindByServiceIdAsync(int serviceId)
    {
        var reservas = await _reservaService.FindByServiceIdAsync(serviceId);
        var resources = _mapper.Map<IEnumerable<Reserva>, IEnumerable<ReservaResource>>(reservas);
        return resources;
    }
}