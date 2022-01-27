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

namespace Application.CourseModule
{
    public class CreateCourse
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Course Course { get; set; }

          
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Course).SetValidator(new CourseValidator());

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

              
                var course = new Course
                {
                    CourseId = request.Course.CourseId,
                    CourseTitle = request.Course.CourseTitle,
                    CourseDescription = request.Course.CourseDescription,
                    DateUploaded = request.Course.DateUploaded,
                    DateModified = request.Course.DateModified,
                    CourseViews = request.Course.CourseViews,
                    CourseRating = request.Course.CourseRating,
                    CourseApprovedBy =  request.Course.CourseApprovedBy,
                    User = user

                };

                user.Courses.Add(course);
              
                _context.Courses.Add(request.Course);
               

               var result = await _context.SaveChangesAsync()  > 0;


                if (!result) return Result<Unit>.Failure("Failed to create course");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}

