using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CourseModule.VideoHandlers
{
   public class CreateVideo
    {
       
        public class Command : IRequest<Result<Unit>>
        {
      
            public Video Video { get; set; }

            public  Guid CourseId { get; set; }


        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Video).SetValidator(new VideoValidator());

            }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly TECHSCOPEContext _context;

            public Handler(TECHSCOPEContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var course = await _context.Courses.FindAsync(request.CourseId);
                if (course == null) return null;


               var video = new Video
                {
                    VideoTitle = request.Video.VideoTitle,

                    VideoDescription = request.Video.VideoDescription,

                    VideoLength = request.Video.VideoLength,

                    Course = course
                };
               
               
                course.Videos.Add(video);

               

                var result = await _context.SaveChangesAsync() > 0;


                if (!result) return Result<Unit>.Failure("Failed to create video");
                return Result<Unit>.Success(Unit.Value);
                /*
                 * var course = await _context.Courses.FindAsync(request.CourseId);
                if (course == null) return null;
               var video = new Video
                {
                    VideoTitle = request.Video.VideoTitle,

                    VideoDescription = request.Video.VideoDescription,

                    VideoLength = request.Video.VideoLength,

                    Course = course
                };
               
               
                course.Videos.Add(video);

                await _context.SaveChangesAsync();

                var result = await _context.SaveChangesAsync() > 0;


                if (result) return Result<VideoDto>.Success(_mapper.Map<VideoDto>(video));

                return Result<VideoDto>.Failure("Failed to add video");
                 */
            }
        }
    }
}
