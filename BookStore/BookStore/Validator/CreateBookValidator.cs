using BookStore.BookOperations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.BookOperations.CreateBookQuery;

namespace BookStore.Validator
{
    public class CreateBookValidator : AbstractValidator<CreateBookQuery>
    {
        public CreateBookValidator()
        {
            RuleFor(r => r.Model.PageCount).GreaterThan(50);
            RuleFor(t => t.Model.Title).MinimumLength(3);
        }
    }
}
