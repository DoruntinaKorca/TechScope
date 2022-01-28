﻿using Application.Core;
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
            private readonly IUsernameAccessor _usernameAccessor;

            public Handler(TECHSCOPEContext context, IUsernameAccessor usernameAccessor, IHostingEnvironment env)
            {
                _context = context;
                _usernameAccessor = usernameAccessor;
                _env = env;
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
                
                Directory.CreateDirectory(_env.ContentRootPath + "/Videos/"+ request.Course.CourseId.ToString());
                user.Courses.Add(course);
              
                _context.Courses.Add(request.Course);
               

               var result = await _context.SaveChangesAsync()  > 0;


                if (!result) return Result<Unit>.Failure("Failed to create course");
                return Result<Unit>.Success(Unit.Value);
            }
          
        }
        
    }
}
