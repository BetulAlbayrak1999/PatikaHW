using AutoMapper;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.GenreOperations
{
    public class DeleteGenreQuery
    {
        private readonly Context _context;
        public int GenreId { get; set; }
        public DeleteGenreQuery(Context context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.Find(GenreId);
            if (genre is null)
                throw new InvalidOperationException("you don't have this genre");
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }

    }
}
