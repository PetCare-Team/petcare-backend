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
[SwaggerTag("Create, read, update, and delete Help Questions")]
public class HelpQuestionsController : ControllerBase
{
    private readonly IHelpQuestionService _helpQuestionService;
    private readonly IMapper _mapper;

    public HelpQuestionsController(IHelpQuestionService helpQuestionService, IMapper mapper)
    {
        _helpQuestionService = helpQuestionService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<HelpQuestionResource>), 200)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Get All Help Questions",
        Description = "Get a list of all Help Questions",
        OperationId = "GetAllHelpQuestions",
        Tags = new[] { "HelpQuestions" }
    )]
    public async Task<IEnumerable<HelpQuestionResource>> GetAllAsync()
    {
        var helpQuestions = await _helpQuestionService.ListAsync();
        var resources = _mapper.Map<IEnumerable<HelpQuestion>, IEnumerable<HelpQuestionResource>>(helpQuestions);
        return resources;
    }

    [HttpPost]
    [ProducesResponseType(typeof(HelpQuestionResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Create a new Help Question",
        Description = "Create a new Help Question with the specified information",
        OperationId = "CreateHelpQuestion",
        Tags = new[] { "HelpQuestions" }
    )]
    public async Task<IActionResult> CreateAsync([FromBody] SaveHelpQuestionResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var helpQuestion = _mapper.Map<SaveHelpQuestionResource, HelpQuestion>(resource);
        var result = await _helpQuestionService.SaveAsync(helpQuestion);

        if (!result.Success)
            return BadRequest(result.Message);

        var helpQuestionResource = _mapper.Map<HelpQuestion, HelpQuestionResource>(result.Resource);
        return Ok(helpQuestionResource);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(HelpQuestionResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Update an existing Help Question",
        Description = "Update an existing Help Question with the specified ID and information",
        OperationId = "UpdateHelpQuestion",
        Tags = new[] { "HelpQuestions" }
    )]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveHelpQuestionResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var helpQuestion = _mapper.Map<SaveHelpQuestionResource, HelpQuestion>(resource);
        var result = await _helpQuestionService.UpdateAsync(id, helpQuestion);

        if (!result.Success)
            return BadRequest(result.Message);

        var helpQuestionResource = _mapper.Map<HelpQuestion, HelpQuestionResource>(result.Resource);
        return Ok(helpQuestionResource);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(HelpQuestionResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Delete an existing Help Question",
        Description = "Delete an existing Help Question with the specified ID",
        OperationId = "DeleteHelpQuestion",
        Tags = new[] { "HelpQuestions" }
    )]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _helpQuestionService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var helpQuestionResource = _mapper.Map<HelpQuestion, HelpQuestionResource>(result.Resource);
        return Ok(helpQuestionResource);
    }

    [HttpGet("user/{userId}")]
    [ProducesResponseType(typeof(HelpQuestionResource), 200)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Get Help Question by User ID",
        Description = "Get a Help Question by the given User ID",
        OperationId = "GetHelpQuestionByUserId",
        Tags = new[] { "HelpQuestions" }
    )]
    public async Task<IActionResult> GetByUserIdAsync(int userId)
    {
        var result = await _helpQuestionService.GetByUserIdAsync(userId);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var helpQuestionResource = _mapper.Map<HelpQuestion, HelpQuestionResource>(result.Resource);
        return Ok(helpQuestionResource);
    }
}