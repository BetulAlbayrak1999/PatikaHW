using BookStore.GenreOperations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validator
{
    public class CreateGenreValidator : AbstractValidator<CreateGenreQuery>
    {
        public CreateGenreValidator()
        {
            RuleFor(r => r.genreModel.Name).MinimumLength(3);
        }
    }
}
