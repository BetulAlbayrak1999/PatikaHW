using BookStore.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validator
{
    public class DeleteBookValidator : AbstractValidator<Book>
    {
        public DeleteBookValidator()
        {
            RuleFor(r => r.PageCount).GreaterThan(50);
            RuleFor(t => t.Title).MinimumLength(3);
            RuleFor(i => i.PublishDate).NotEmpty();
            RuleFor(i => i.Id).GreaterThan(0);

        }
    }
}
