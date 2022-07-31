using BookStore.AuthorOperations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validator
{
    public class GetAuthorByIdValidator : AbstractValidator<GetAuthorByIdQuery>
    {
        public GetAuthorByIdValidator()
        {
            RuleFor(r => r.Id).GreaterThan(0);
        }
    }
}
