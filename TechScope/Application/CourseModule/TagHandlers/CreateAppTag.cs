using Application.Core;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CourseModule.TagHandlers
{
   public class CreateAppTag
    {
        public class Command : IRequest<Result<Unit>>
        {
            public AppTag AppTag { get; set; }

            public Guid CourseId { get; set; }
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

                var appTag = new AppTag
                {
                    TagName = request.AppTag.TagName,
                    Course = course
                };

                 course.AppTags.Add(appTag);


                var result = await _context.SaveChangesAsync() > 0;

                if(!result)
                {
                    return Result<Unit>.Failure("Failed to create appTags");

                }
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
