using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers.v1
{
    [ApiVersion("1.0")] //option for versioning. the api-version parameter will be required in the request url https://localhost:44355/api/test/get-test-data?api-version=1.0
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")] ////second option for versioning
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("get-test-data")]
        public IActionResult Get()
        {
            return Ok("This is TestController V1.0");
        }

        [HttpGet("get-test-data"), MapToApiVersion("2.0")]
        public IActionResult GetV2()
        {
            return Ok("This is TestController V2.0");
        }

        [HttpGet("get-test-data"), MapToApiVersion("3.0")]
        public IActionResult GetV3()
        {
            return Ok("This is TestController V3.0");
        }
    }
}
