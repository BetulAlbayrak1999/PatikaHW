using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.BookOperations.CreateBookQuery;

namespace BookStore.Validator
{
    public class CreateBookValidator : AbstractValidator<CreateBookModel>
    {
        public CreateBookValidator()
        {
            RuleFor(r => r.PageCount).GreaterThan(50);
            RuleFor(t => t.Title).MinimumLength(3);
        }
    }
}
