using BookStore.BookOperations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.BookOperations.UpdateBookQuery;

namespace BookStore.Validator
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookQuery>
    {
        public UpdateBookValidator() 
        {
            RuleFor(r => r.Model.PageCount).GreaterThan(50);
            RuleFor(t => t.Model.Title).MinimumLength(3);
            RuleFor(i => i.Model.PublishDate).NotEmpty();
            RuleFor(i => i.Model.GenreId).GreaterThan(0);
        }
    }
}
