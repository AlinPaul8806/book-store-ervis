using BookStore.Data.Models;
using BookStore.Data.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Data.Services
{
    public class PublishersService
    {
        // reference to the
        // db context:
        private AppDbContext _context;

        //constructor:
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM publisherVM)
        {
            var _publisher = new Publisher()
            {
                Name = publisherVM.Name,
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public List<Publisher> GetAllPublishers()
        { 
            var publishers = _context.Publishers.ToList();  
            return publishers;
        }

        public Publisher GetPublisher(int id)
        { 
            var publisher = _context.Publishers.FirstOrDefault(x => x.Id == id);
            return publisher;
        }

        public Publisher UpdatePublisher(int id, PublisherVM publisherVM)
        { 
            var _publisher = _context.Publishers.FirstOrDefault(x => x.Id == id);
            if (_publisher != null)
            {
                _publisher.Name = publisherVM.Name;
                _context.SaveChanges();
            }
            return _publisher;
        }

        public void DeletePublisher(int id)
        { 
            var publisher = _context.Publishers.FirstOrDefault(x => x.Id == id);
            _context.Remove(publisher);
            _context.SaveChanges();
        }
    }
}
