using Microsoft.AspNetCore.Mvc;
using TaskTracker.Backend.Repositories;

namespace TaskTracker.Backend.Controllers
{
    [ApiController]
    [Route("api/user/")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        public UserController(ILogger<UserController> logger, IUserRepository usertRepository)
        {
            _logger = logger;
            _userRepository = usertRepository;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetUserList()
        {
            return Ok(await _userRepository.GetUserListAsync());
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            (bool success, User? newUser) = await _userRepository.CreateUserAsync(user);
            return success ? Created($"api/user/{newUser?.Id}", newUser) : BadRequest();
        }

    }
}
