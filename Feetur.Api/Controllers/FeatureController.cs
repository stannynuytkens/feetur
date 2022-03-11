using Feetur.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Feetur.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FeatureController : ControllerBase
{
    private readonly ILogger<FeatureController> _logger;

    public FeatureController(ILogger<FeatureController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Feature> Get()
    {
        return new List<Feature>();
    }
}