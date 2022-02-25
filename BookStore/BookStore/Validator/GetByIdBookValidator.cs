using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.BookOperations.GetBookById;

namespace BookStore.Validator
{
    public class GetByIdBookValidator : AbstractValidator<BooksViewModelDetail>
    {
        public GetByIdBookValidator() 
        {
            RuleFor(r => r.PageCount).GreaterThan(50);
            RuleFor(t => t.Title).MinimumLength(3);
            RuleFor(i => i.PublishDate).NotEmpty();
        }
    }
}
