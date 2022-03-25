using BookStore.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BookStore.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "Hobbit",
                        Description = "The hobbit book",
                        IsRead = true,
                        DateRead = System.DateTime.Now.AddDays(-10),
                        Rate = 5,
                        Genre = "Fantasy",
                        CoverUrl = "https://mir-s3-cdn-cf.behance.net/project_modules/1400/56d96263885635.5acd0047cf3e6.jpg",
                        DateAdded = System.DateTime.Now
                    },
                    new Book()
                    {
                        Title = "Some are sicker than others",
                        Description = "Gripping novel debut by Andrew Seaward.",
                        IsRead = false,
                        Genre = "Crime",
                        CoverUrl = "https://s3.amazonaws.com/htw/dt-contest-entries/78059/united-states-contemporary-fiction-thriller-transgressive-fiction-urban-fiction-addiction-fiction-book-cover-design.png",
                        DateAdded = System.DateTime.Now
                    },
                    new Book()
                    {
                        Title = "Vampires: Trinity",
                        Description = "Four brothers all turned into vampires.",
                        IsRead = true,
                        DateRead = System.DateTime.Now.AddDays(-28),
                        Rate = 3,
                        Genre = "Fantasy",
                        CoverUrl = "http://www.indiedesignz.com/blog/wp-content/uploads/2011/12/vampire_print.jpg",
                        DateAdded = System.DateTime.Now
                    },
                    new Book()
                    {
                        Title = "Yseult",
                        Description = "A tale of love in the age of king Arthur",
                        IsRead = true,
                        DateRead = System.DateTime.Now.AddDays(-20),
                        Rate = 5,
                        Genre = "Romance",
                        CoverUrl = "https://www.creativindiecovers.com/wp-content/uploads/2012/01/Yseultframe1.jpg",
                        DateAdded = System.DateTime.Now
                    });

                    context.SaveChanges();

                }
            }
        }
    }
}
