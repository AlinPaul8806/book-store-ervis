using BookStore.Data.Models;
using BookStore.Data.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Data.Services
{
    public class AuthorsService
    {
        // reference to the books db context:
        private AppDbContext _context;

        //constructor:
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM authorVM)
        {
            var _author = new Author()
            {
                FullName = authorVM.FullName,
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public List<Author> GetAllAuthors()
        {
            var allAuthors = _context.Authors.ToList();
            return allAuthors;
        }

        public Author GetAuthor(int id)
        { 
            var author = _context.Authors.FirstOrDefault(x => x.Id == id);
            return author;
        }

        public Author UpdateAuthor(int id, AuthorVM authorVM)
        { 
            var _author = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (_author != null)
            {
                _author.FullName = authorVM.FullName;
                _context.SaveChanges();
            }
            return _author;
        }

        public void DeleteAuthor(int id)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == id);
            _context.Authors.Remove(author);
        }
    }
}
