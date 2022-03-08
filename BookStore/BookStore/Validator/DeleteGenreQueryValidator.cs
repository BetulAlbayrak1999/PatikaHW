using BookStore.GenreOperations;
using BookStore.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validator
{
    public class DeleteGenreQueryValidator : AbstractValidator<DeleteGenreQuery>
    {
        public DeleteGenreQueryValidator()
        {
            RuleFor(r => r.GenreId).GreaterThan(0);
        }
    }
}

