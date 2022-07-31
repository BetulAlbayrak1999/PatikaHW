using AutoMapper;
using BookStore.AuthorOperations;
using BookStore.Models;
using BookStore.Validator;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.AuthorOperations.CreateAuthorQuery;
using static BookStore.AuthorOperations.UpdateAuthorQuery;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public AuthorController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel author) 
        {
            CreateAuthorQuery query = new CreateAuthorQuery(_context,_mapper);
            CreateAuthorValidator validator = new CreateAuthorValidator();
            query.Model = author;
            validator.ValidateAndThrow(query);
            query.Handle();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAuthor() 
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int Id) 
        {
            DeleteAuthorQuery query = new DeleteAuthorQuery(_context);
            DeleteAuthorValidator validator = new DeleteAuthorValidator();
            query.Id = Id;
            validator.ValidateAndThrow(query);
            query.Handle();
            return Ok();
        }

        [HttpGet("GetAuthorById")]
        public IActionResult GetAuthorById(int Id)
        {
            GetAuthorByIdQuery query = new GetAuthorByIdQuery(_context, _mapper);
            GetAuthorByIdValidator validator = new GetAuthorByIdValidator();
            query.Id = Id;
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem([FromBody] UpdateAuthorModel author, int id)
        {
            UpdateAuthorQuery query = new UpdateAuthorQuery(_context, _mapper);
            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            query.Id = id;
            query.Model = author;
            validator.ValidateAndThrow(query);

            query.Handle();
            return Ok();
        }
    }
}
