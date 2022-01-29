using Application.Core;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.IO;
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
            public string Id { get; set; }

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
            private IHostingEnvironment _env;
            
            private readonly TECHSCOPEContext _context;
          

            public Handler(TECHSCOPEContext context, IHostingEnvironment env)
            {
                _context = context;
          
                _env = env;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id);
                if (user == null) return null;


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
              

               var result = await _context.SaveChangesAsync()  > 0;

                Directory.CreateDirectory(Path.Combine(_env.ContentRootPath,"Videos", course.CourseId.ToString()));
                if (!result) return Result<Unit>.Failure("Failed to create course");
                return Result<Unit>.Success(Unit.Value);
            }
          
        }
        
    }
}