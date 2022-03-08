using BookStore.GenreOperations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validator
{
    public class UpdateGenreQueryValidator : AbstractValidator<UpdateGenreQuery>
    {
        public UpdateGenreQueryValidator()
        {
            RuleFor(r => r.Model.Name).MinimumLength(3).When(x=> x.Model.Name!= string.Empty);
        }
    }
}
