using BookStore.AuthorOperations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Validator
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorQuery>
    {
        public CreateAuthorValidator()
        {
            RuleFor(r => r.Model.Name).MinimumLength(3);
            RuleFor(r => r.Model.Surname).MinimumLength(3);
            RuleFor(r => r.Model.BirthDate).MinimumLength(3);
        }
    }
}
