using Microsoft.AspNetCore.Mvc;

namespace CatalyaCMS.Api.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok();
        }
    }
}