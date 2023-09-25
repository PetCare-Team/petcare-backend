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
[SwaggerTag("Create, read, update and delete Reviews")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;
    private readonly IMapper _mapper;

    public ReviewsController(IReviewService reviewService, IMapper mapper)
    {
        _reviewService = reviewService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ReviewResource>), 200)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Get All Reviews",
        Description = "Get a list of all Reviews",
        OperationId = "GetAllReviews",
        Tags = new[] { "Reviews" }
    )]
    public async Task<IEnumerable<ReviewResource>> GetAllAsync()
    {
        var reviews = await _reviewService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(reviews);
        return resources;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ReviewResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Create a new Review",
        Description = "Create a new Review with the specified information",
        OperationId = "CreateReview",
        Tags = new[] { "Reviews" }
    )]
    public async Task<IActionResult> CreateAsync([FromBody] SaveReviewResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var review = _mapper.Map<SaveReviewResource, Review>(resource);
        var result = await _reviewService.SaveAsync(review);

        if (!result.Success)
            return BadRequest(result.Message);

        var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
        return Ok(reviewResource);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ReviewResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Update an existing Review",
        Description = "Update an existing Review with the specified ID and information",
        OperationId = "UpdateReview",
        Tags = new[] { "Reviews" }
    )]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveReviewResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var review = _mapper.Map<SaveReviewResource, Review>(resource);
        var result = await _reviewService.UpdateAsync(id, review);

        if (!result.Success)
            return BadRequest(result.Message);

        var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
        return Ok(reviewResource);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ReviewResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Delete an existing Review",
        Description = "Delete an existing Review with the specified ID",
        OperationId = "DeleteReview",
        Tags = new[] { "Reviews" }
    )]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _reviewService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
        return Ok(reviewResource);
    }
    
    [HttpGet("byService/{serviceId}")]
    [ProducesResponseType(typeof(IEnumerable<ReviewResource>), 200)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Get All Reviews by Service ID",
        Description = "Get a list of all Reviews based on a specific Service ID",
        OperationId = "GetReviewsByServiceId",
        Tags = new[] { "Reviews" }
    )]
    public async Task<IEnumerable<ReviewResource>> FindByServiceIdAsync(int serviceId)
    {
        var reviews = await _reviewService.ListByServiceIdAsync(serviceId);
        var resources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(reviews);
        return resources;
    }

    [HttpGet("byUser/{userId}")]
    [ProducesResponseType(typeof(IEnumerable<ReviewResource>), 200)]
    [ProducesResponseType(500)]
    [SwaggerOperation(
        Summary = "Get All Reviews by User ID",
        Description = "Get a list of all Reviews based on a specific User ID",
        OperationId = "GetReviewsByUserId",
        Tags = new[] { "Reviews" }
    )]
    public async Task<IEnumerable<ReviewResource>> FindByUserIdAsync(int userId)
    {
        var reviews = await _reviewService.ListByUserIdAsync(userId);
        var resources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(reviews);
        return resources;
    }
}
