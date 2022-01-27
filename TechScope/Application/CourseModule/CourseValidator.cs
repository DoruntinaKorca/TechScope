using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CourseModule
{
  public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(x => x.CourseTitle).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Course title can't be empty !!")
                .Length(1, 200).WithMessage("Course title can't be longer than 200 characters"); 
           
            RuleFor(x => x.CourseDescription).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Course description can't be empty !!")
                .Length(1, 250).WithMessage("Course description can't be longer than 250 characters");
        }
    }
}
