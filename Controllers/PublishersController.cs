using BookStore.Data;
using BookStore.Data.Models.ViewModels;
using BookStore.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _publishersService;
        private readonly ILogger<PublishersController> _logger;

        public PublishersController(PublishersService publishersService, ILogger<PublishersController> logger)
        {
            _publishersService = publishersService;
            _logger = logger;
        }

        [HttpGet("get-all-publishers")] // --> ("get-all-publishers") = custom url
        public IActionResult GetAllPublishers(string sortBy, string searchString, int pageNumber)
        {
            try
            {
                _logger.LogInformation("this is a test log in GetAllPublishers() --> Publishers controller.");
                var publishers = _publishersService.GetAllPublishers(sortBy, searchString, pageNumber);
                return Ok(publishers);
            }
            catch (Exception)
            {
                return BadRequest("Sorry, we could not load the publishers.");
            }
        }


        [HttpGet("get-publisher-by-id/{id}")] // --> the is param comes from the url
        public IActionResult GetPublisher(int id)
        {
            var publisher = _publishersService.GetPublisher(id);
            if (publisher != null)
            {
                return Ok(publisher);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost("add-publisher")] // --> ("add-publisher") = custom url
        public IActionResult AddPublisher([FromBody] PublisherVM publisherVM)
        {
            var publisher = _publishersService.AddPublisher(publisherVM);
            if (publisher != null)
            {
                return Created(nameof(AddPublisher), publisher);
            }
            else 
            {
                return StatusCode(StatusCodes.Status409Conflict); //Conflict, for updates that fail due to conflicts such as already exists etc..
            }
        }


        [HttpPut("update-publisher-by-id/{id}")] // id= same name as in the method param
        public IActionResult UpdatePublisher(int id, [FromBody] PublisherVM publisherVM)
        {
            var updatedPublisher = _publishersService.UpdatePublisher(id, publisherVM);
            if (updatedPublisher != null)
            {
                return Ok(updatedPublisher);
            }
            else
            {
                return StatusCode(StatusCodes.Status409Conflict); //Conflict, for updates that fail due to conflicts such as already exists etc..
            }
        }


        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisher(int id)
        {
            try
            {
                _publishersService.DeletePublisher(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
