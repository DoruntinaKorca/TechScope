using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserModule.PreferenceHandlers
{
    class PreferenceValidator : AbstractValidator<Preference>
    {
        public PreferenceValidator()
        {
            RuleFor(x => x.PreferenceName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Preference title can't be empty !!");

           
        }
    }
}
