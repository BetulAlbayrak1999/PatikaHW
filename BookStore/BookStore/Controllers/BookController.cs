using AutoMapper;
using BookStore.BookOperations;
using BookStore.Models;
using BookStore.Validator;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.BookOperations.CreateBookQuery;
using static BookStore.BookOperations.GetBookByIdQuery;
using static BookStore.BookOperations.UpdateBookQuery;

namespace BookStore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public BookController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBook()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateItem([FromBody] UpdateBookModel book, int id)
        {
            UpdateBookQuery query = new UpdateBookQuery(_context, _mapper);
            UpdateBookValidator validator = new UpdateBookValidator();
            query.id = id;
            query.Model = book;
            validator.ValidateAndThrow(query);

            query.Handle();
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] CreateBookModel book)
        {
            CreateBookQuery query = new CreateBookQuery(_context, _mapper);
            CreateBookValidator validator = new CreateBookValidator();
            ValidationResult result = new ValidationResult();
            query.Model = book;
            validator.ValidateAndThrow(query);
            query.Handle();
           
            return Ok();
        }

        [HttpGet("GetBookById")]
        public IActionResult GetBookById(int Id)
        {
            BooksViewModelDetail result;
            GetBookByIdQuery query = new GetBookByIdQuery(_context, _mapper);
            query.Id = Id;
            GetByIdBookValidator validator = new GetByIdBookValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        
        }

        [HttpDelete("DeleteBook")]
        public IActionResult DeleteBook(int Id)
        {
            DeleteBookValidator validator = new DeleteBookValidator();
            ValidationResult result = new ValidationResult();
            DeleteBookQuery query = new DeleteBookQuery(_context);
            query.Id = Id;
            validator.ValidateAndThrow(query);
            query.Handle();

            return Ok();
        }
        private bool ItemExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

    }
}