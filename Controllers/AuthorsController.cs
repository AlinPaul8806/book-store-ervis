using BookStore.Data.Models.ViewModels;
using BookStore.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        public AuthorsService _authorsService;

        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }


        [HttpGet("get-all-authors")] // --> ("get-all-authors") = custom url
        public IActionResult GetAllAuthors()
        {
            var authors = _authorsService.GetAllAuthors();
            return Ok(authors);
        }


        [HttpGet("get-author-by-id/{id}")] // --> the is param comes from the url
        public IActionResult GetAuthor(int id)
        {
            var author = _authorsService.GetAuthor(id);
            return Ok(author);
        }


        [HttpPost("add-author")] // --> ("add-book") = custom url
        public IActionResult AddAuthor([FromBody] AuthorVM authorVM)
        {
            _authorsService.AddAuthor(authorVM);
            return Ok();
        }


        [HttpPut("update-author-by-id/{id}")] // id= same name as in the method param
        public IActionResult UpdateAuthor(int id, [FromBody] AuthorVM authorVM)
        {
            var updatedAuthor = _authorsService.UpdateAuthor(id, authorVM);
            return Ok(updatedAuthor);
        }

        [HttpDelete("delete-author-by-id/{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            _authorsService.DeleteAuthor(id);
            return Ok();
        }

    }
}
