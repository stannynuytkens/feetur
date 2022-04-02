using Feetur.Api.Hubs;
using Feetur.Shared;
using Feetur.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Feetur.Api.Controllers;

/// <summary>
/// A controller to manage features
/// /// </summary>
[ApiController]
[Route("feature")]
public class FeatureController : ControllerBase
{
    private readonly ILogger<FeatureController> _logger;
    private readonly IHubContext<FeatureHub> _hubContext;

    /// <summary>
    /// Creates an instance of <see cref="FeatureController"/>
    /// </summary>
    /// <param name="logger">The <see cref="ILogger{TCategoryName}"/> used for logging</param>
    /// <param name="hubContext">The SignalR <see cref="FeatureHub"/> context</param>
    public FeatureController(ILogger<FeatureController> logger, IHubContext<FeatureHub> hubContext)
    {
        _logger = logger;
        _hubContext = hubContext;
    }

    /// <summary>
    /// Delete a feature
    /// </summary>
    /// <param name="featureId">The ID of the feature to delete</param>
    /// <returns></returns>
    [HttpDelete("{featureId:guid}")]
    public Task<IActionResult> DeleteFeature(Guid featureId)
    {
        return Task.FromResult<IActionResult>(NoContent());
    }
    
    /// <summary>
    /// Get a feature by Id
    /// </summary>
    /// <param name="featureId">The Id of the feature to get</param>
    /// <returns>The result that contains the found feature</returns>
    [HttpGet("{featureId:guid}")]
    public Task<IActionResult> GetFeature(Guid featureId)
    {
        var feature = new Feature
        {
            Id = featureId,
            Name = nameof(Feature),
            Enabled = true
        };
        
        return Task.FromResult<IActionResult>(Ok(feature));
    }

    /// <summary>
    /// Returns all features
    /// </summary>
    /// <returns>All the found features</returns>
    [HttpGet]
    public Task<IActionResult> GetAllFeatures()
    {
        var features = new List<Feature>
        {
            new Feature
            {
                Id = Guid.NewGuid(),
                Name = nameof(Feature),
                Enabled = true
            }
        };

        return Task.FromResult<IActionResult>(Ok(features));
    }
    
    /// <summary>
    /// Create a feature
    /// </summary>
    /// <param name="feature">The feature to create</param>
    /// <returns></returns>
    [HttpPost]
    public Task<IActionResult> CreateFeature([FromBody]Feature? feature)
    {
        // suppress null warning because fluent validation will provide 4xx
        feature!.Id = Guid.NewGuid();
        
        return Task.FromResult<IActionResult>(CreatedAtAction(nameof(GetFeature), new { featureId = feature.Id }, feature));
    }

    /// <summary>
    /// Toggles a features state
    /// </summary>
    /// <param name="featureId">The Id of the feature to toggle</param>
    /// <param name="enabled">The new state of the feature</param>
    /// <returns></returns>
    [HttpPatch("{featureId:guid}")]
    public async Task<IActionResult> ToggleFeature(Guid featureId, bool enabled)
    {
        var feature = new Feature
        {
            Id = featureId,
            Name = nameof(Feature),
            Enabled = enabled
        };

        if (feature is null)
            return await Task.FromResult<IActionResult>(NotFound());
        
        await _hubContext.Clients.All.SendAsync(nameof(IFeatureClient.Notify), feature);
        
        return Ok(feature);
    }
}