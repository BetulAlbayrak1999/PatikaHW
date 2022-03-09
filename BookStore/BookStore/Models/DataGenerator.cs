using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (context.Books.Any()) { return; }
                    

                context.Genres.AddRange(
                    new Genre { Name= "Romance"},
                    new Genre { Name= "Sceince Fiction"},
                    new Genre { Name= "Fantasy"}
                    );


                context.Books.AddRange(
                    new Book
                    {
                        Title = "1.book",
                        GenreId = 1,
                        PageCount = 234,
                        PublishDate = DateTime.Now
                    },
                    new Book
                    {
                        Title = "2.book",
                        GenreId = 2,
                        PageCount = 455,
                        PublishDate = DateTime.UtcNow
                    }
                );

                context.SaveChanges();
            }
        }
    }
}


