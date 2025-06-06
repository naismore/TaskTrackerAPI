using Microsoft.AspNetCore.Mvc;


namespace TaskTracker.Backend.Controllers
{
    [ApiController]
    [Route("api/user/")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserRepository _userRepository;
        public UserController(ILogger<UserController> logger, UserRepository usertRepository)
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
            if (success)
            {
                return Created($"api/user/{newUser?.Id}", newUser);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
