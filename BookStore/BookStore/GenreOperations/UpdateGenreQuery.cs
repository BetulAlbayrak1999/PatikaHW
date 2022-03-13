using AutoMapper;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.GenreOperations
{
    public class UpdateGenreQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }
        public UpdateGenreQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _context.Genres.Find(GenreId);
            if (genre is null)
                throw new InvalidOperationException("we don't have this genre");
            if(_context.Genres.Any(x=>x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
                throw new InvalidOperationException("we have this name");

            genre.Name = string.IsNullOrEmpty(Model.Name.Trim())? genre.Name : Model.Name;
            genre.IsActive = Model.IsActive;
            _context.Genres.Update(genre);
            _context.SaveChanges();
        }
    }
    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
