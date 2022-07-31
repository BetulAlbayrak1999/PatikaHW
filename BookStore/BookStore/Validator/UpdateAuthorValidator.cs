using BookStore.AuthorOperations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validator
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorQuery>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(r => r.Model.Name).MinimumLength(3);
            RuleFor(t => t.Model.Surname).MinimumLength(3);
            RuleFor(i => i.Model.BirthDate).NotEmpty();
            RuleFor(i => i.Id).GreaterThan(0);
        }
    }
}
