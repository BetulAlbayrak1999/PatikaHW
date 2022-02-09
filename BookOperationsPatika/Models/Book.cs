using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookOperationsPatika.Models
{
    public class Book
    {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public string Title { get; set; }

            public string GenreType { get; set; }

            public int PageCount { get; set; }

            public string PublishDate { get; set; }
       
    }
}
