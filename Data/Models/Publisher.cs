using System.Collections.Generic;

namespace BookStore.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        //navigation proiperties; props that define relations between the models:
        public List<Book> Books { get; set; }

    }
}
