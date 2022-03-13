using BookStore.BookOperations;
using BookStore.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validator
{
    public class DeleteBookValidator : AbstractValidator<DeleteBookQuery>
    {
        public DeleteBookValidator()
        {
            RuleFor(i => i.Id).GreaterThan(0);
        }
    }
}
