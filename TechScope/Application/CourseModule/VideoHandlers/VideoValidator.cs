using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CourseModule.VideoHandlers
{
    public class VideoValidator : AbstractValidator<Video>
    {
        public VideoValidator()
        {
            RuleFor(x => x.VideoTitle).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Video title can't be empty !!")
                .Length(1, 200).WithMessage("Video title can't be longer than 200 characters");

            RuleFor(x => x.VideoDescription).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Video description can't be empty !!")
                .Length(1, 250).WithMessage("Video description can't be longer than 250 characters");
        }
    }
}
