using System.Collections.Generic;

namespace BookStore.Data.Models
{
    public class Author
    {
        public int Id { get; set; } 
        public string FullName { get; set; }

        //Navigational Properties
        public List<Book_Author> BookAuthors { get; set; }
    }
}
