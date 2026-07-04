using bbl_dev_fest_2026_sirasith_klinfuengfu.IServices;
using bbl_dev_fest_2026_sirasith_klinfuengfu.Models;
using Microsoft.AspNetCore.Mvc;

namespace bbl_dev_fest_2026_sirasith_klinfuengfu.Controllers
{
    [ApiController]
    [Route("users")]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("getById/{userId:long}")]
        public ActionResult<User> GetById(long userId)
        {
            var user = _userService.GetById(userId);
            if (user is null)
            {
                return NotFound(new { message = $"User with id {userId} was not found." });
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<User> Create([FromBody] UserRequest request)
        {
            var created = _userService.Create(request);
            return CreatedAtAction(nameof(GetById), new { userId = created.id }, created);
        }

        [HttpPut("update/{userId:long}")]
        public ActionResult<User> Update(long userId, [FromBody] UserRequest request)
        {
            var updated = _userService.Update(userId, request);
            if (updated is null)
            {
                return NotFound(new { message = $"User with id {userId} was not found." });
            }

            return Ok(updated);
        }

        [HttpDelete("delete/{userId:long}")]
        public IActionResult Delete(long userId)
        {
            var deleted = _userService.Delete(userId);
            if (!deleted)
            {
                return NotFound(new { message = $"User with id {userId} was not found." });
            }

            return NoContent();
        }
    }
}
