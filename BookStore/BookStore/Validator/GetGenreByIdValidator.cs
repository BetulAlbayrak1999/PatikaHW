using BookStore.GenreOperations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validator
{
    public class GetGenreByIdValidator : AbstractValidator<GetGenreByIdQuery>
    {
        public void GetByIdBookValidator() {
            RuleFor(r => r.GenreId).GreaterThan(0);
        }
    }
}
