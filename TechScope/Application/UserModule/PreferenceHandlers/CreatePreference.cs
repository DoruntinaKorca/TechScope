using Application.Core;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserModule.PreferenceHandlers
{
    public class CreatePreference
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Preference Preference { get; set; }

        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Preference).SetValidator(new PreferenceValidator());

            }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly TECHSCOPEContext _context;
            private readonly IUsernameAccessor _usernameAccessor;

            public Handler(TECHSCOPEContext context, IUsernameAccessor usernameAccessor)
            {
                _context = context;
                _usernameAccessor = usernameAccessor;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x =>
               x.UserName == _usernameAccessor.GetUsername());


                var userPreferences = new UserPreference
                {
                    User = user,
                    Preference = request.Preference
                };


               
                request.Preference.UserPreferences.Add(userPreferences);

                _context.Preferences.Add(request.Preference);


                var result = await _context.SaveChangesAsync() > 0;


                if (!result) return Result<Unit>.Failure("Failed to create preference");

                return Result<Unit>.Success(Unit.Value);

            }

        }
    }
}
