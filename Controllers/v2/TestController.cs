using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers.v2
{
    [ApiVersion("2.0")] //option for versioning. the api-version parameter will be required in the request url https://localhost:44382/api/test/get-tes-data?api-version=2.0
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")] ////second option for versioning
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("get-test-data")]
        public IActionResult Get()
        {
            return Ok("This is TestController V2");
        }
    }
}
