using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CourseModule.TagHandlers
{
   public class TagValidator : AbstractValidator<Tag>
    {
        public TagValidator()
        {
            RuleFor(x => x.TagName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Tag name can't be empty !!")
                .MaximumLength(50).WithMessage("Tag name can't be longer than 50 characters");

        }
    }
}
