using api.DTO.Users;
using api.Exceptions;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")] // api/users
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost] // POST api/users
        public ActionResult<UserDto> Create(UserCreateDto userCreateDto)
        {
            var user = userCreateDto.ToUser();

            try
            {
                _usersService.Create(user);
            }
            catch (UserAlreadyExistsException e)
            {
                return Conflict(e.Message);
            }

            return UserDto.FromUser(user);
        }

        [HttpGet("{id:int}")] // GET api/users/{id}
        public ActionResult<UserDto> GetById(int id)
        {
            var user = _usersService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return UserDto.FromUser(user);
        }

        [HttpPut("{id:int}")] // PUT api/users/{id}
        public IActionResult Update(int id, UserUpdateDto updateDto)
        {
            var user = _usersService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Nickname = updateDto.Nickname;
            user.Password = updateDto.Password;
            user.Mood = updateDto.Mood;

            _usersService.SaveChanges();

            return NoContent(); // client already has the user, no need to return
        }

        [HttpDelete("{id:int}")] // DELETE api/users/{id}
        public IActionResult Delete(int id)
        {
            var user = _usersService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            _usersService.Delete(user);

            return Ok();
        }

        [HttpPost("login")] // POST api/users/login
        public ActionResult<string> FakeLogin(UserLoginDto loginDto)
        {
            var user = _usersService.GetByNickname(loginDto.Nickname);

            if (user == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(loginDto.Password))
            {
                return BadRequest("Password is required");
            }

            if (!_usersService.ValidatePassword(user, loginDto.Password))
            {
                return Unauthorized();
            }

            return "Login successful";
        }
    }
}
