using BookStore.Data.Models;
using BookStore.Data.Models.ViewModels;
using System;
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

        public Publisher AddPublisher(PublisherVM publisherVM)
        {
            var _publisher = new Publisher()
            {
                Name = publisherVM.Name,
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }

        public List<Publisher> GetAllPublishers(string sortBy, string searchString, int? pageNumber)
        { 
            //searching:
            var publishers = _context.Publishers.OrderBy(n => n.Name).ToList();
            if (string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "name_desc":
                        publishers = publishers.OrderByDescending(n => n.Name).ToList();
                        break;
                    default:
                        break;
                }
            }
            
            if (!string.IsNullOrEmpty(searchString))
            {
                //localhost:44382/api/publishers/get-all-publishers?sortBy=name_desc&searchString=New
                publishers = publishers.Where(n => n.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            //paging:
            int pageSize = 5;
            publishers = PaginatedList<Publisher>.Create(publishers.AsQueryable(), pageNumber ?? 1, pageSize);

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
            if (publisher != null)
            {
                _context.Remove(publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"The publisher id: {id}, does not exist.");
            }
        }
    }
}
