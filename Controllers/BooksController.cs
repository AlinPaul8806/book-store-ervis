using BookStore.Data.Models;
using BookStore.Data.Models.ViewModels;
using BookStore.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // --> decorator. API or MVC controller
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }


        [HttpGet("get-all-books")] // --> ("get-all-books") = custom url
        public IActionResult GetAllBooks()
        {
            var books = _booksService.GetAllBooks();
            return Ok(books);
        }


        [HttpGet("get-book-by-id/{id}")] // --> the is param comes from the url
        public IActionResult GetBook(int id)
        {
            var book = _booksService.GetBook(id);
            return Ok(book);
        }


        [HttpPost("add-book")] // --> ("add-book") = custom url
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }


        [HttpPut("update-book-by-id/{id}")] // id= same name as in the method param
        public IActionResult UpdateBook(int id, [FromBody] BookVM bookVM)
        {
            var updatedBook = _booksService.UpdateBook(id, bookVM);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _booksService.DeleteBook(id);
            return Ok();
        }
    }
}
