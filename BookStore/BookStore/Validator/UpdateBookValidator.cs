using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.BookOperations.UpdateBookQuery;

namespace BookStore.Validator
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookModel>
    {
        public UpdateBookValidator() 
        {
            RuleFor(r => r.PageCount).GreaterThan(50);
            RuleFor(t => t.Title).MinimumLength(3);
            RuleFor(i => i.PublishDate).NotEmpty();
            RuleFor(i => i.GenreId).GreaterThan(0);
        }
    }
}
