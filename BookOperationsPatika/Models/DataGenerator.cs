using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOperationsPatika.Models
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (context.Books.Any())
                    return;
                context.Books.AddRange(
                    new Book{
                        Id = 1,
                        Title = "1.book",
                        GenreType = "science fiction",
                        PageCount = 234,
                        PublishDate = "12/03/1999"
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "2.book",
                        GenreType = "science",
                        PageCount = 455,
                        PublishDate = "11/1/1111"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}


