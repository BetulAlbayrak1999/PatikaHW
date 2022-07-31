using BookStore.AuthorOperations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validator
{
    public class DeleteAuthorValidator : AbstractValidator<DeleteAuthorQuery>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(i => i.Id).GreaterThan(0);
        }
    }
}
