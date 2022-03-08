using AutoMapper;
using BookStore.GenreOperations;
using BookStore.Models;
using BookStore.Validator;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.GenreOperations.UpdateGenreQuery;

namespace BookStore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public GenreController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreDetail(int id) 
        {
            GetGenreById query = new GetGenreById(_context, _mapper);
            query.GenreId = id;
            GetGenreByIdValidator validator = new GetGenreByIdValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenreQuery query = new GetGenreQuery(_context, _mapper);
            var obj = query.Handle();
            return Ok(obj);
        }
        
        [HttpPost]
        public IActionResult AddGenre([FromBody]CreateGenreModel genre) 
        {
            CreateGenreQuery query = new CreateGenreQuery(_context);
            query.genreModel = genre;
            CreateGenreValidator validator = new CreateGenreValidator();
            validator.ValidateAndThrow(query);

            query.Handle();
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel genre)
        {
            UpdateGenreQuery query = new UpdateGenreQuery(_context);
            query.GenreId = id;
            query.Model = genre;
            UpdateGenreQueryValidator validator = new UpdateGenreQueryValidator();
            validator.ValidateAndThrow(query);

            query.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreQuery query = new DeleteGenreQuery(_context);
            query.GenreId = id;
            DeleteGenreQueryValidator validator = new DeleteGenreQueryValidator();
            validator.ValidateAndThrow(query);

            query.Handle();
            return Ok();
        }
    }
}
