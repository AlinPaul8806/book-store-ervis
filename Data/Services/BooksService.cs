using BookStore.Data.Models;
using BookStore.Data.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Data.Services
{
    public class BooksService
    {
        // reference to the books db context:
        private AppDbContext _context;

        //constructor:
        public BooksService(AppDbContext context)
        {
            _context = context; 
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks()
        { 
            var allBooks = _context.Books.ToList();
            return allBooks;
        }

        public Book GetBook(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            return book;
        }

        public Book UpdateBook(int id, BookVM bookVM)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (_book != null)
            {
                _book.Title = bookVM.Title;
                _book.Description = bookVM.Description;
                _book.IsRead = bookVM.IsRead;
                _book.DateRead = bookVM.IsRead ? bookVM.DateRead.Value : null;
                _book.Rate = bookVM.IsRead ? bookVM.Rate.Value : null;
                _book.Genre = bookVM.Genre;
                _book.Author = bookVM.Author;
                _book.CoverUrl = bookVM.CoverUrl;

                _context.SaveChanges();
            }
            return _book;
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
