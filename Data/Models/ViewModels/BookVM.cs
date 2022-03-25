using System;
using System.Collections.Generic;

namespace BookStore.Data.Models.ViewModels
{
    public class BookVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }  // ? --> optional
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }

        //Navigational props:
        public int PublisherId { get; set; }
        public List<int> AuthorIds { get; set; }
    }
}
