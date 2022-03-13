using BookStore.BookOperations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.BookOperations.GetBookByIdQuery;

namespace BookStore.Validator
{
    public class GetByIdBookValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetByIdBookValidator() 
        {
            RuleFor(r => r.Id).GreaterThan(0);
        }
    }
}
