using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RollesController : ControllerBase
    {

        [HttpGet("get-Rolles")]
        public IActionResult Rolles()
        {
            return Ok(new JsonResult(new { message = "Only Authorized Users can View Players" }));
        }
    }
}
