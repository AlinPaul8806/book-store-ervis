using BookStore.Data;
using BookStore.Data.Models.ViewModels;
using BookStore.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublishersService _publishersService;
        public PublishersController(PublishersService publishersService)
        {
            publishersService = _publishersService;
        }

        [HttpGet("get-all-publishers")] // --> ("get-all-publishers") = custom url
        public IActionResult GetAllPublishers()
        {
            var publishers = _publishersService.GetAllPublishers();
            return Ok(publishers);
        }


        [HttpGet("get-publisher-by-id/{id}")] // --> the is param comes from the url
        public IActionResult GetPublisher(int id)
        {
            var publisher = _publishersService.GetPublisher(id);
            return Ok(publisher);
        }


        [HttpPost("add-publisher")] // --> ("add-publisher") = custom url
        public IActionResult AddPublisher([FromBody] PublisherVM publisherVM)
        {
            _publishersService.AddPublisher(publisherVM);
            return Ok();
        }


        [HttpPut("update-publisher-by-id/{id}")] // id= same name as in the method param
        public IActionResult UpdatePublisher(int id, [FromBody] PublisherVM publisherVM)
        {
            var updatedPublisher = _publishersService.UpdatePublisher(id, publisherVM);
            return Ok(updatedPublisher);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisher(int id)
        {
            _publishersService.DeletePublisher(id);
            return Ok();
        }

    }
}
