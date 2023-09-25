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
[SwaggerTag("Create, read, update and delete FAQs")]
public class FAQsController : ControllerBase
{
    private readonly IFAQService _faqService;
    private readonly IMapper _mapper;

    public FAQsController(IFAQService faqService, IMapper mapper)
    {
        _faqService = faqService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<FAQResource>), 200)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Get All FAQs",
        Description = "Get a list of all FAQs",
        OperationId = "GetAllFAQs",
        Tags = new[] { "FAQs" }
    )]
    public async Task<IEnumerable<FAQResource>> GetAllAsync()
    {
        var faqs = await _faqService.ListAsync();
        var resources = _mapper.Map<IEnumerable<FAQ>, IEnumerable<FAQResource>>(faqs);
        return resources;
    }

    [HttpPost]
    [ProducesResponseType(typeof(FAQResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Create a new FAQ",
        Description = "Create a new FAQ with the specified information",
        OperationId = "CreateFAQ",
        Tags = new[] { "FAQs" }
    )]
    public async Task<IActionResult> CreateAsync([FromBody] SaveFAQResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var faq = _mapper.Map<SaveFAQResource, FAQ>(resource);
        var result = await _faqService.SaveAsync(faq);

        if (!result.Success)
            return BadRequest(result.Message);

        var faqResource = _mapper.Map<FAQ, FAQResource>(result.Resource);
        return Ok(faqResource);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(FAQResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Update an existing FAQ",
        Description = "Update an existing FAQ with the specified ID and information",
        OperationId = "UpdateFAQ",
        Tags = new[] { "FAQs" }
    )]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveFAQResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var faq = _mapper.Map<SaveFAQResource, FAQ>(resource);
        var result = await _faqService.UpdateAsync(id, faq);

        if (!result.Success)
            return BadRequest(result.Message);

        var faqResource = _mapper.Map<FAQ, FAQResource>(result.Resource);
        return Ok(faqResource);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(FAQResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Delete an existing FAQ",
        Description = "Delete an existing FAQ with the specified ID",
        OperationId = "DeleteFAQ",
        Tags = new[] { "FAQs" }
    )]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _faqService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var faqResource = _mapper.Map<FAQ, FAQResource>(result.Resource);
        return Ok(faqResource);
    }
}
