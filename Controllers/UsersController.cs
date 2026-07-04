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
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("{userId:long}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> Create([FromBody] UserRequest request)
        {
            var created = _userService.Create(request);
            return CreatedAtAction(nameof(GetById), new { userId = created.id }, created);
        }

        [HttpPut("{userId:long}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> Update(long userId, [FromBody] UserRequest request)
        {
            var updated = _userService.Update(userId, request);
            if (updated is null)
            {
                return NotFound(new { message = $"User with id {userId} was not found." });
            }

            return Ok(updated);
        }

        [HttpDelete("{userId:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
