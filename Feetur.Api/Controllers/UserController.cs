using Feetur.Api.Models;
using Feetur.Application.Data;
using Microsoft.AspNetCore.Mvc;

namespace Feetur.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UserController> _logger;

    public UserController(IUnitOfWork unitOfWork, ILogger<UserController> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _unitOfWork.UserRepository.GetAllAsync(default(CancellationToken));

        return Ok(users?.Select(u => new User
        {
            FirstName = u.FirstName,
            LastName = u.LastName,
            Email = u.Email,
            Active = u.Active
        }) ?? new List<User>());
    }
}